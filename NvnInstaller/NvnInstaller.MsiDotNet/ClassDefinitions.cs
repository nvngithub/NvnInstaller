#define DEBUG1

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace NvnInstaller.MsiDotNet {
    public class MsiFeature {
        internal string ParentId;

        private string id;
        private MsiFeature parentFeature;
        private List<MsiFeature> childFeatures;
        private string title;
        private string description;
        private int display;
        private string directory;
        private long featureCost;
        private long totalCost;
        private bool enabled = true;
        private bool isAlreadyInstalled = false;

        /// <summary>Unique identifier of the feature</summary>
        public string Id { get { return id; } }
        /// <summary>Parent feature of given feature in the feature tree.</summary>
        public MsiFeature ParentFeature { get { return parentFeature; } }
        /// <summary>List of child features. This can be used to used construct feature tree.</summary>
        public List<MsiFeature> ChildFeatures { get { return childFeatures; } }
        /// <summary>Short string of text identifying the feature. This string is listed as an item by the SelectionTree control</summary>
        public string Title { get { return title; } }
        /// <summary>Longer string of text describing the feature. </summary>
        public string Description { get { return description; } }
        /// <summary>Specifies whether this feature is enabled or not.</summary>
        public int Display { get { return display; } }
        ///// <summary>Specify the Id of a Directory that can be configured by the user at installation time. </summary>
        //public string Directory { get { return directory; } }
        /// <summary>Number of bytes required for installing this feature.</summary>
        public long FeatureCost { get { return featureCost; } }
        /// <summary>Number of bytes required for installing this feature. This also includes child features.</summary>
        public long TotalCost { get { return totalCost; } }
        /// <summary>Only enabled features are installed Windows Installer.</summary>
        public bool Enabled { get { return enabled; } }
        /// <summary>Specifies whether this feature is already installed on local system.</summary>
        public bool IsAlreadyInstalled { get { return isAlreadyInstalled; } }

        internal void SetId(string id) { this.id = id; }
        internal void SetParent(MsiFeature parent) { this.parentFeature = parent; }
        internal void SetChildFeature(List<MsiFeature> childFeatures) { this.childFeatures = childFeatures; }
        internal void SetTitle(string title) { this.title = title; }
        internal void SetDescription(string desc) { this.description = desc; }
        internal void SetDisplay(int display) { this.display = display; }
        internal void SetDirectory(string dir) { this.directory = dir; }
        internal void SetFeatureCost(long cost) { this.featureCost = cost; }
        internal void SetTotalCost(long cost) { this.totalCost = cost; }
        internal void SetEnabled(bool enabled) { this.enabled = enabled; }
        internal void SetIsAlreadyInstalled(bool installed) { this.isAlreadyInstalled = installed; }
    }

    internal class MsiComponent {
        public string Id;
        public int FileSize;
    }

#if DEBUG
    public class LogMessage : EventArgs {
        private string message;

        public string Message { get { return message; } }

        public LogMessage(string message) {
            this.message = message;
        }
    }
#endif

    public class InstallerMessage {
        protected InstallerMessageType type;

        /// <summary>InstallerMessageType</summary>
        public InstallerMessageType Type { get { return type; } set { type = value; } }
    }

    #region Progres Messages
    public class ResetMessage : InstallerMessage {
        private int ticks;
        private ProgressDirection direction;
        private bool isApproximate;

        /// <summary>Total number of ticks in the progress bar</summary>
        public int Ticks { get { return ticks; } }
        /// <summary>Progress bar motion direction</summary>
        public ProgressDirection Direction { get { return direction; } }
        /// <summary>The estimate of the total number of ticks is an approximation and may be inaccurate.</summary>
        public bool IsApproximate { get { return isApproximate; } }

        internal void SetTicks(int ticks) { this.ticks = ticks; }
        internal void SetDirection(ProgressDirection direction) { this.direction = direction; }
        internal void SetIsApproximate(bool isApproximate) { this.isApproximate = isApproximate; }

        public ResetMessage() { this.type = InstallerMessageType.ResetMessage; }
    }

    //public class ActionInfoMessage : InstallerMessage {
    //  private int ticksPerActionData;
    //  private bool ignoreTicksPerActionData;

    //  /// <summary>Number of ticks the progress bar moves for each ActionData message sent by the current action</summary>
    //  public int TicksPerActionData { get { return ticksPerActionData; } }
    //  /// <summary>Whether or not to use TicksPerActionData property</summary>
    //  public bool IgnoreTicksPerActionData { get { return ignoreTicksPerActionData; } }

    //  internal void SetTicksPerActionData(int ticks) { this.ticksPerActionData = ticks; }
    //  internal void SetIgnoreTicksPerActionData(bool ignore) { this.ignoreTicksPerActionData = ignore; }

    //  public ActionInfoMessage() { this.type = InstallerMessageType.ActionInfo; }
    //}

    public class ProgressReportMessage : InstallerMessage {
        private int ticksMoved;

        /// <summary>Number of ticks the progress bar has moved</summary>
        public int TicksMoved { get { return ticksMoved; } }

        internal void SetTicksMoved(int ticks) { this.ticksMoved = ticks; }

        public ProgressReportMessage() { this.type = InstallerMessageType.ProgressReport; }
    }

    //public class ProgressAdditionMessage : InstallerMessage {
    //  private int ticks;

    //  /// <summary>Number of ticks to add to total expected count of progress ticks</summary>
    //  public int Ticks { get { return ticks; } }

    //  internal void SetTicks(int ticks) { this.ticks = ticks; }

    //  public ProgressAdditionMessage() { this.type = InstallerMessageType.ProgressAddition; }
    //}
    #endregion

    public class ActionStartMessage : InstallerMessage {
        private string time;
        private string action;
        private string description;

        /// <summary>Time when the action was started</summary>
        public string Time { get { return time; } }
        /// <summary>Action name in MSI database sequence table</summary>
        public string Action { get { return action; } }
        /// <summary>Description of the current action started by windows installer</summary>
        public string Description { get { return description; } }

        internal void SetTime(string time) { this.time = time; }
        internal void SetAction(string action) { this.action = action; }
        internal void SetDescription(string description) { this.description = description; }

        public ActionStartMessage() { this.type = InstallerMessageType.ActionStart; }
    }

    public class ActionDataMessage : InstallerMessage {
        protected string message;

        /// <summary>Formatted message received from Windows Installer describing current action.</summary>
        public string Message { get { return message; } }

        internal void SetFormattedMessage(string message) { this.message = message; }

        public ActionDataMessage() { this.type = InstallerMessageType.ActionData; }
    }

    public class InformationMessage : InstallerMessage {
        protected string message;

        /// <summary>Formatted user/log message</summary>
        public string Message { get { return message; } }

        internal void SetFormattedMessage(string message) { this.message = message; }

        public InformationMessage() { this.type = InstallerMessageType.Information; }
    }

    public class InstallCompleteMessage : InstallerMessage {
        protected bool success;

        /// <summary>Specifies whether installation is successful or not</summary>
        public bool Success { get { return success; } }

        internal void SetSuccessStatus(bool success) { this.success = success; }

        public InstallCompleteMessage() { this.type = InstallerMessageType.InstallationComplete; }
    }

    public class FileInUseMessage : InstallerMessage {
        private string filePath;

        /// <summary>Location of the file which is supposed to be removed by uninstallation or overwritten by new installation</summary>
        public string FilePath { get { return filePath; } }

        internal void SetFilePath(string filepath) { this.filePath = filepath; }

        public FileInUseMessage() { this.type = InstallerMessageType.FileInUse; }
    }

    public class ErrorMessage : InstallerMessage {
        protected string message;
        private ErrorMessageType errorMessageType;

        /// <summary>Formatted error message received from Windows Installer</summary>
        public string Message { get { return message; } }
        /// <summary>Specifies whether message is Error, FatalExit or Warning</summary>
        public ErrorMessageType ErrorMessageType { get { return errorMessageType; } }

        internal void SetFormattedMessage(string message) { this.message = message; }
        internal void SetErrorMessageType(ErrorMessageType errorMessageType) { this.errorMessageType = errorMessageType; }

        public ErrorMessage() { this.type = InstallerMessageType.Error; }
    }

    public class InstallerMessageEventArgs : EventArgs {
        private InstallerMessage installerMessage;
        private bool setUserAction = false;

        /// <summary>Message received from Windows Installer. This message can be type casted to specific types for detailed information.</summary>
        public InstallerMessage InstallerMessage { get { return installerMessage; } }
        /// <summary>Windows Installer needs user input to continue installation. Ex: MsiResponse.Cancel to cancel installation.</summary>
        public bool SetUserAction { get { return setUserAction; } }

        internal void SetMessage(InstallerMessage message) { this.installerMessage = message; }
        internal void SetIsWaitingUserAction(bool waiting) { this.setUserAction = waiting; }

        internal InstallerMessageEventArgs() { }

        internal InstallerMessageEventArgs(InstallerMessage installerMessage, bool setUserAction) {
            this.installerMessage = installerMessage;
            this.setUserAction = setUserAction;
        }
    }

    #region Enumerations
    public enum InstallerMessageType {
        /// <summary>Error message received from windows installer. Use ErrorMessage for detailed information</summary>
        Error,
        /// <summary>Information/User message received from windows installer. Use InformationMessage for detailed information</summary>
        Information,
        /// <summary>ActionStart message received from windows installer. Use ActionStartMessage for detailed information</summary>
        ActionStart,
        /// <summary>ActionData message received from windows installer. Use ActionDataMessage for detailed information</summary>
        ActionData,
        /// <summary>ResetMessage message received from windows installer. Use ResetMessage for detailed information</summary>
        ResetMessage,
        /// <summary>ProgressReport message received from windows installer. Use ProgressReportMessage for detailed information</summary>
        ProgressReport,
        /// <summary>FileInUse message received from windows installer. Use FileInUseMessage for detailed information</summary>
        FileInUse,
        /// <summary>InstallationComplete message received from windows installer. Use InstallCompleteMessage for detailed information</summary>
        InstallationComplete
    }

    public enum ProgressDirection {
        /// <summary>Forward motion of progress bar</summary>
        Forward,
        /// <summary>Backward motion of progress bar</summary>
        Backward
    }

    public enum InstallationStatus {
        /// <summary>Installation thread started</summary>
        Started,
        /// <summary>Installer thread is already running</summary>
        AlreadyRunning,
        /// <summary>Unknown error accured while starting installation</summary>
        UnknownError
    }

    public enum ErrorMessageType {
        /// <summary></summary>
        FatalExit,
        /// <summary>Formatted error message</summary>
        Error,
        /// <summary>Formatted warning message</summary>
        Warning
    }

    public enum MsiResponse {
        None,
        /// <summary>The OK button was pressed by the user. The message information was understood.</summary>
        OK,
        /// <summary>	The CANCEL button was pressed. Cancel the installation.</summary>
        Cancel,
        /// <summary>The ABORT button was pressed. Abort the installation.</summary>
        Abort,
        /// <summary>The RETRY button was pressed. Try the action again.</summary>
        Retry,
        /// <summary>The IGNORE button was pressed. Ignore the error and continue.</summary>
        Ignore,
        /// <summary>The YES button was pressed. The affirmative response, continue with current sequence of events.</summary>
        Yes,
        /// <summary>The NO button was pressed. The negative response, do not continue with current sequence of events.</summary>
        No
    }
    #endregion
}