using System;

namespace DeepSeekAI.HarnessBridge.Models {
    [Serializable]
    public class CommandRequest {
        public string id;
        public string action;
        public CommandParams @params;
    }

    [Serializable]
    public class CommandParams {
        public string testMode;
        public string filter;
        public string limit;

        // Build command params
        public string method;       // Fully qualified static method (e.g., "DeepSeekAI.Builder.BuildEntryPoints.BuildQuest")
        public string target;       // BuildTarget enum name (e.g., "Android", "StandaloneWindows64")
        public string development;  // "true"/"false" - development build flag
        public string env;          // Semicolon-separated KEY=VALUE pairs
        public string output;       // Output path override

        // Asset dependency analysis params (asset graph commands)
        public string asset;            // Target asset path or GUID (get-dependencies / find-references / get-asset-info)
        public string from;             // Start asset path or GUID (trace-path)
        public string to;               // End asset path or GUID (trace-path)
        public string recursive;        // "true"/"false" - include transitive dependencies (get-dependencies)
        public string maxDepth;         // Integer - BFS depth limit (trace-path)
        public string type;             // Asset type filter, e.g. "Prefab" or "Texture2D" (search-assets)
        public string query;            // Search query (search-assets)
        public string includePackages;  // "true"/"false" - include Packages/ in scans
    }
}
