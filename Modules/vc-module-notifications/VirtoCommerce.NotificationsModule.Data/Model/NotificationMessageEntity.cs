using System;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.NotificationsModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.NotificationsModule.Data.Model
{
    /// <summary>
    /// Entity is message of notification
    /// </summary>
    public class NotificationMessageEntity : AuditableEntity
    {
        /// <summary>
        /// Tenant id that initiate sending
        /// </summary>
        [StringLength(128)]
        public string TenantId { get; set; }

        /// <summary>
        /// Tenant type that initiate sending
        /// </summary>
        [StringLength(128)]
        public string TenantType { get; set; }

        /// <summary>
        /// Id of notification
        /// </summary>
        [StringLength(128)]
        public string NotificationId { get; set; }

        /// <summary>
        /// Type of notification
        /// </summary>
        [StringLength(128)]
        public string NotificationType { get; set; }

        /// <summary>
        /// Number of current attemp
        /// </summary>
        public int SendAttemptCount { get; set; }

        /// <summary>
        /// Maximum number of attempts to send a message
        /// </summary>
        public int MaxSendAttemptCount { get; set; }

        /// <summary>
        /// Last fail attempt error message
        /// </summary>
        public string LastSendError { get; set; }

        /// <summary>
        /// Date of last fail attempt
        /// </summary>
        public DateTime? LastSendAttemptDate { get; set; }

        /// <summary>
        /// Date of start sending notification
        /// </summary>
        public DateTime? SendDate { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        [StringLength(10)]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Subject of notification
        /// </summary>
        [StringLength(512)]
        public string Subject { get; set; }

        /// <summary>
        /// Body of notification
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Message of notification
        /// </summary>
        [StringLength(1600)]
        public string Message { get; set; }

        /// <summary>
        /// Notification property
        /// </summary>
        public NotificationEntity Notification { get; set; }

        public virtual NotificationMessage ToModel(NotificationMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            message.Id = this.Id;
            message.TenantIdentity = new TenantIdentity(this.TenantId, this.TenantType);
            message.NotificationId = this.NotificationId;
            message.NotificationType = this.NotificationType;
            message.SendAttemptCount = this.SendAttemptCount;
            message.MaxSendAttemptCount = this.MaxSendAttemptCount;
            message.LastSendError = this.LastSendError;
            message.LastSendAttemptDate = this.LastSendAttemptDate;
            message.SendDate = this.SendDate;
            message.CreatedBy = this.CreatedBy;
            message.CreatedDate = this.CreatedDate;
            message.ModifiedBy = this.ModifiedBy;
            message.ModifiedDate = this.ModifiedDate;

            return message;
        }

        public virtual NotificationMessageEntity FromModel(NotificationMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            this.Id = message.Id;
            this.TenantId = message.TenantIdentity?.Id;
            this.TenantType = message.TenantIdentity?.Type;
            this.NotificationId = message.NotificationId;
            this.NotificationType = message.NotificationType;
            this.SendAttemptCount = message.SendAttemptCount;
            this.MaxSendAttemptCount = message.MaxSendAttemptCount;
            this.LastSendError = message.LastSendError;
            this.LastSendAttemptDate = message.LastSendAttemptDate;
            this.SendDate = message.SendDate;
            this.CreatedBy = message.CreatedBy;
            this.CreatedDate = message.CreatedDate;
            this.ModifiedBy = message.ModifiedBy;
            this.ModifiedDate = message.ModifiedDate;

            return this;
        }

        public virtual void Patch(NotificationMessageEntity message)
        {
            message.TenantId = this.TenantId;
            message.TenantType = this.TenantType;
            message.Notification = this.Notification;
            message.Body = this.Body;
            message.LanguageCode = this.LanguageCode;
            message.NotificationId = this.NotificationId;
            message.NotificationType = this.NotificationType;
            message.SendAttemptCount = this.SendAttemptCount;
            message.MaxSendAttemptCount = this.MaxSendAttemptCount;
            message.LastSendError = this.LastSendError;
            message.LastSendAttemptDate = this.LastSendAttemptDate;
            message.SendDate = this.SendDate;
        }
    }
}
