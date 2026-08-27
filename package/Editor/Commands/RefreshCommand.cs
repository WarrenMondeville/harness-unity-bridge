using System;
using System.Diagnostics;
using DeepSeekAI.HarnessBridge.Models;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace DeepSeekAI.HarnessBridge.Commands {
    public class RefreshCommand : ICommand {
        public void Execute(CommandRequest request, Action<CommandResponse> onProgress, Action<CommandResponse> onComplete) {
            var stopwatch = Stopwatch.StartNew();

#if DEBUG
            Debug.Log(HarnessBridge.LogPrefix + " Refreshing asset database");
#endif

            var response = CommandResponse.Running(request.id, request.action);
            onProgress?.Invoke(response);

            try {
                AssetDatabase.Refresh();
                stopwatch.Stop();

#if DEBUG
                Debug.Log(HarnessBridge.LogPrefix + " Asset database refresh completed");
#endif
                onComplete?.Invoke(CommandResponse.Success(request.id, request.action, stopwatch.ElapsedMilliseconds));
            }
            catch (Exception e) {
                stopwatch.Stop();
                Debug.LogError($"{HarnessBridge.LogPrefix} Asset database refresh failed: {e.Message}");
                onComplete?.Invoke(CommandResponse.Error(request.id, request.action, e.Message));
            }
        }
    }
}
