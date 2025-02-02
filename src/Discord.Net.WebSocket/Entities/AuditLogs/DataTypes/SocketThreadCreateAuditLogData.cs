using Discord.API.AuditLogs;
using Discord.Rest;
using System.Collections.Generic;
using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.WebSocket;

/// <summary>
///     Contains a piece of audit log data related to a thread creation.
/// </summary>
public class SocketThreadCreateAuditLogData : ISocketAuditLogData
{
    private SocketThreadCreateAuditLogData(ulong id, ThreadInfoAuditLogModel model)
    {
        ThreadId = id;

        ThreadName = model.Name;
        IsArchived = model.IsArchived!.Value;
        AutoArchiveDuration = model.ArchiveDuration!.Value;
        IsLocked = model.IsLocked!.Value;
        SlowModeInterval = model.SlowModeInterval;
        AppliedTags = model.AppliedTags;
        Flags = model.ChannelFlags;
        ThreadType = model.Type;
    }

    internal static SocketThreadCreateAuditLogData Create(DiscordSocketClient discord, EntryModel entry)
    {
        var changes = entry.Changes;

        var (_, data) = AuditLogHelper.CreateAuditLogEntityInfo<ThreadInfoAuditLogModel>(changes, discord);

        return new SocketThreadCreateAuditLogData(entry.TargetId!.Value, data);
    }

    /// <summary>
    ///     Gets the snowflake ID of the thread.
    /// </summary>
    /// <returns>
    ///     A <see cref="ulong"/> representing the snowflake identifier for the thread.
    /// </returns>
    public ulong ThreadId { get; }

    /// <summary>
    ///     Gets the name of the thread.
    /// </summary>
    /// <returns>
    ///     A string containing the name of the thread.
    /// </returns>
    public string ThreadName { get; }

    /// <summary>
    ///     Gets the type of the thread.
    /// </summary>
    /// <returns>
    ///     The type of thread.
    /// </returns>
    public ThreadType ThreadType { get; }

    /// <summary>
    ///     Gets the value that indicates whether the thread is archived.
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if this thread has the Archived flag enabled; otherwise <see langword="false" />.
    /// </returns>
    public bool IsArchived { get; }

    /// <summary>
    ///     Gets the auto archive duration of the thread.
    /// </summary>
    /// <returns>
    ///     The thread auto archive duration of the thread.
    /// </returns>
    public ThreadArchiveDuration AutoArchiveDuration { get; }

    /// <summary>
    ///     Gets the value that indicates whether the thread is locked.
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if this thread has the Locked flag enabled; otherwise <see langword="false" />.
    /// </returns>
    public bool IsLocked { get; }

    /// <summary>
    ///     Gets the slow-mode delay of the thread.
    /// </summary>
    /// <returns>
    ///     An <see cref="int"/> representing the time in seconds required before the user can send another
    ///     message; <c>0</c> if disabled.
    ///     <see langword="null" /> if this is not mentioned in this entry.
    /// </returns>
    public int? SlowModeInterval { get; }

    /// <summary>
    ///     Gets the applied tags of this thread.
    /// </summary>
    /// <remarks>
    ///     <see langword="null"/> if the property was not updated.
    /// </remarks>
    public IReadOnlyCollection<ulong> AppliedTags { get; }

    /// <summary>
    ///     Gets the flags of the thread channel.
    /// </summary>
    /// <remarks>
    ///     <see langword="null"/> if the property was not updated.
    /// </remarks>
    public ChannelFlags? Flags { get; }
}
