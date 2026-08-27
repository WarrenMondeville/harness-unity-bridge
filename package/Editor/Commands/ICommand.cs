using System;
using DeepSeekAI.HarnessBridge.Models;

namespace DeepSeekAI.HarnessBridge.Commands {
    public interface ICommand {
        void Execute(CommandRequest request, Action<CommandResponse> onProgress, Action<CommandResponse> onComplete);
    }
}
