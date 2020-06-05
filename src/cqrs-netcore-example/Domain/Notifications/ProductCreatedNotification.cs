using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace netcore_docker.Domain.Notifications
{
	public class ProductCreatedNotification : INotification
	{
		public DateTime EventTime { get; } = DateTime.UtcNow;
		public string Code { get; set; }
	}

	public class ProductNotificationHandler1 : INotificationHandler<ProductCreatedNotification>
	{
		public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken) {
			Debug.WriteLine($"ProductNotificationHandler 1 code: {notification.Code} time {notification.EventTime}");
			return Task.CompletedTask;
		}
	}

	public class ProductNotificationHandler2 : INotificationHandler<ProductCreatedNotification>
	{
		public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken) {
			Debug.WriteLine($"ProductNotificationHandler 2 code: {notification.Code} time {notification.EventTime}");
			return Task.CompletedTask;
		}
	}
}