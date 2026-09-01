using GTranslate.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;

namespace Gumani_AAPD7112w_POE
{
    public class TranslationService
    {       
        private readonly GoogleTranslator _translator = new GoogleTranslator();
        private readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();

        private string CacheKey(string text, string lang) => $"{lang}:{text}";

        public async Task<string> TranslateAsync(string text, string targetLang)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            var key = CacheKey(text, targetLang);
            if (_cache.TryGetValue(key, out var cached)) return cached;

            var translation = await TranslateWithRetryAsync(text, targetLang);
            _cache.TryAdd(key, translation);
            return translation;
        }

        private async Task<string> TranslateWithRetryAsync(string text, string targetLang)
        {
            const int maxAttempts = 5;
            var attempt = 0;
            var delay = TimeSpan.FromSeconds(1);

            while (true)
            {
                attempt++;
                try
                {
                    var result = await _translator.TranslateAsync(text, targetLang);
                    return result.Translation;
                }
                catch (HttpRequestException ex) when (attempt < maxAttempts)
                {
                    await Task.Delay(delay);
                    delay = TimeSpan.FromSeconds(delay.TotalSeconds * 2);
                    continue;
                }
            }
        }
    }
}
