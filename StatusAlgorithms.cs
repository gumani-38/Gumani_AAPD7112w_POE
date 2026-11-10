using System;
using System.Collections.Generic;

namespace Gumani_AAPD7112w_POE
{

    // MIN-HEAP (PRIORITY QUEUE) FOR URGENCY SORTING
    public class IssueMinHeap
    {
        private List<IssueReport> heap = new List<IssueReport>();

        public int Count => heap.Count;

        public void Insert(IssueReport report)
        {
            heap.Add(report);
            HeapifyUp(heap.Count - 1);
        }

        public IssueReport ExtractMin()
        {
            if (heap.Count == 0) return null;

            IssueReport minItem = heap[0];
            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return minItem;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                // Compare priority scores (Lower score = Higher urgency)
                if (heap[index].PriorityScore < heap[parentIndex].PriorityScore)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else break;
            }
        }

        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;
            while (true)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int smallest = index;

                if (leftChild <= lastIndex && heap[leftChild].PriorityScore < heap[smallest].PriorityScore)
                    smallest = leftChild;

                if (rightChild <= lastIndex && heap[rightChild].PriorityScore < heap[smallest].PriorityScore)
                    smallest = rightChild;

                if (smallest != index)
                {
                    Swap(index, smallest);
                    index = smallest;
                }
                else break;
            }
        }

        private void Swap(int i, int j)
        {
            IssueReport temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
    // BINARY SEARCH TREE  FOR TRACKING ID LOOKUP

    public class BSTNode
    {
        public IssueReport Data;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode(IssueReport report)
        {
            Data = report;
            Left = null;
            Right = null;
        }
    }

    public class ServiceRequestBST
    {
        private BSTNode root;

        public void Insert(IssueReport report)
        {
            root = InsertRec(root, report);
        }

        private BSTNode InsertRec(BSTNode root, IssueReport report)
        {
            if (root == null)
                return new BSTNode(report);

            // Compare tracking alphanumeric keys (lexicographical check)
            if (string.Compare(report.UniqueId, root.Data.UniqueId) < 0)
                root.Left = InsertRec(root.Left, report);
            else if (string.Compare(report.UniqueId, root.Data.UniqueId) > 0)
                root.Right = InsertRec(root.Right, report);

            return root;
        }

        public IssueReport Search(string uniqueId)
        {
            return SearchRec(root, uniqueId);
        }

        private IssueReport SearchRec(BSTNode root, string uniqueId)
        {
            if (root == null || root.Data.UniqueId == uniqueId)
                return root?.Data;

            if (string.Compare(uniqueId, root.Data.UniqueId) < 0)
                return SearchRec(root.Left, uniqueId);

            return SearchRec(root.Right, uniqueId);
        }
    }

// WORKFLOW GRAPH FOR SERVICE PROGRESS TRAVERSAL
    
    public class ServiceWorkflowGraph
    {
        private Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

        public ServiceWorkflowGraph()
        {
            // Define municipal pipeline state milestones
            AddDependency("Report Logged", "Verification Pending");
            AddDependency("Verification Pending", "Dispatched to Team");
            AddDependency("Dispatched to Team", "In Progress");
            AddDependency("In Progress", "Quality Check");
            AddDependency("Quality Check", "Resolved");
        }

        private void AddDependency(string fromStatus, string toStatus)
        {
            if (!adjacencyList.ContainsKey(fromStatus)) adjacencyList[fromStatus] = new List<string>();
            if (!adjacencyList.ContainsKey(toStatus)) adjacencyList[toStatus] = new List<string>();
            adjacencyList[fromStatus].Add(toStatus);
        }

        // BFS/DFS Traversal algorithm tracking progress milestones down the pipeline
        public List<string> TrackMilestonePipeline(string currentStatus)
        {
            List<string> operationalPath = new List<string>();
            Queue<string> nodesToVisit = new Queue<string>();
            HashSet<string> seen = new HashSet<string>();

            if (!adjacencyList.ContainsKey(currentStatus))
            {
                operationalPath.Add(currentStatus);
                return operationalPath;
            }

            nodesToVisit.Enqueue(currentStatus);
            seen.Add(currentStatus);

            while (nodesToVisit.Count > 0)
            {
                string state = nodesToVisit.Dequeue();
                operationalPath.Add(state);

                foreach (string nextState in adjacencyList[state])
                {
                    if (!seen.Contains(nextState))
                    {
                        seen.Add(nextState);
                        nodesToVisit.Enqueue(nextState);
                    }
                }
            }
            return operationalPath;
        }
    }
}
