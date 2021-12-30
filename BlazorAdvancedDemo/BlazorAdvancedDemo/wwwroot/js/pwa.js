window.addEventListener('beforeinstallprompt', function (e) {
    e.preventDefault();
    // Stash the event so it can be triggered later.
    // where you store it is up to you
    window.PWADeferredPrompt = e;
    // Notify C# Code that it can show an alert 
    // MyBlazorInstallMethod must be [JSInvokable]
    DotNet.invokeMethodAsync("BlazorAdvancedDemo", "MyBlazorInstallMethod");
});

window.BlazorPWA = {
    installPWA: function () {
        if (window.PWADeferredPrompt) {
            // Use the stashed event to continue the install process
            window.PWADeferredPrompt.prompt();
            window.PWADeferredPrompt.userChoice
                .then(function (choiceResult) {
                    window.PWADeferredPrompt = null;
                });
        }
    }
};