using GTranslate.Translators; // Contains BingTranslator and AggregateTranslator
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gumani_AAPD7112w_POE
{
    public class TranslationService : IDisposable
    {

        private readonly AggregateTranslator _translator;
        private readonly ConcurrentDictionary<string, string> _cache;
        private readonly SemaphoreSlim _requestLock;
        private bool _disposed;

        public TranslationService()
        {
    
            _translator = new AggregateTranslator();
            _cache = new ConcurrentDictionary<string, string>();
            _requestLock = new SemaphoreSlim(1, 1);
        }

        private string GetCacheKey(string text, string language)
        {
            return $"{language}:{text}";
        }

        public async Task<string> TranslateAsync(string text, string targetLang)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            string key = GetCacheKey(text, targetLang);
            if (_cache.TryGetValue(key, out string cached)) return cached;

            await _requestLock.WaitAsync();
            try
            {
                if (_cache.TryGetValue(key, out cached)) return cached;

            
                var result = await _translator.TranslateAsync(text, targetLang);
                if (result != null && !string.IsNullOrWhiteSpace(result.Translation))
                {
                    _cache[key] = result.Translation;
                    return result.Translation;
                }
                return text;
            }
            catch (Exception)
            {
                return text;
            }
            finally
            {
                await Task.Delay(1000);
                _requestLock.Release();
            }
        }

        public async Task<Dictionary<string, string>> TranslateBatchAsync(IEnumerable<string> texts, string targetLang)
        {
            var distinctTexts = texts.Where(t => !string.IsNullOrWhiteSpace(t)).Distinct().ToList();
            var resultsMap = new Dictionary<string, string>();

            if (!distinctTexts.Any()) return resultsMap;

            var textsToTranslate = new List<string>();
            foreach (var text in distinctTexts)
            {
                string key = GetCacheKey(text, targetLang);
                if (_cache.TryGetValue(key, out string cached))
                {
                    resultsMap[text] = cached;
                }
                else
                {
                    textsToTranslate.Add(text);
                }
            }

            if (!textsToTranslate.Any()) return resultsMap;

            await _requestLock.WaitAsync();
            try
            {
                string combinedText = string.Join("\n----\n", textsToTranslate);
                var result = await _translator.TranslateAsync(combinedText, targetLang);

                if (result != null && !string.IsNullOrWhiteSpace(result.Translation))
                {
                    string[] translatedParts = result.Translation.Split(new[] { "\n----\n", "\n---- \n", " \n ---- \n" }, StringSplitOptions.None);

                    for (int i = 0; i < textsToTranslate.Count; i++)
                    {
                        string original = textsToTranslate[i];
                        string translated = (i < translatedParts.Length) ? translatedParts[i].Trim() : original;

                        string cacheKey = GetCacheKey(original, targetLang);
                        _cache[cacheKey] = translated;
                        resultsMap[original] = translated;
                    }
                }
                else
                {
                    foreach (var original in textsToTranslate) resultsMap[original] = original;
                }
            }
            catch (Exception)
            {
                foreach (var original in textsToTranslate) resultsMap[original] = original;
            }
            finally
            {
                await Task.Delay(1500);
                _requestLock.Release();
            }

            return resultsMap;
        }

        public void ClearCache() => _cache.Clear();

        public void Dispose()
        {
            if (!_disposed)
            {
                _requestLock?.Dispose();
                _translator?.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
