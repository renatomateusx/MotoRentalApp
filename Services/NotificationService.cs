// NotificationService.cs
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

public class NotificationService: INotificationService
{
    private readonly IAmazonSimpleNotificationService _sns;

    public NotificationService(IAmazonSimpleNotificationService sns)
    {
        _sns = sns;
    }

    public async Task NotifyMotoCreatedAsync(Moto moto)
    {
        if (moto.Ano == 2024)
        {
            // Publica mensagem para o SNS
            var message = $"Moto {moto.Identificador} do ano 2024 cadastrada.";
            await _sns.PublishAsync(new PublishRequest
            {
                Message = message,
                TopicArn = "arn:aws:sns:region:account-id:topic-name"
            });
        }
    }
}