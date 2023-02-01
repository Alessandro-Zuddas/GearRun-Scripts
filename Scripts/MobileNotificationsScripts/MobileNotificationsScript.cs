using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;


public class MobileNotificationsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Rimuovo notifiche gia viste
        AndroidNotificationCenter.CancelAllDisplayedNotifications();



        //Creazione del canale di notifica android

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);


        //Creazione della notifica

        var notification = new AndroidNotification();
        notification.Title = "Hey! Gear is so sad!";
        notification.Text = "Look at his face.... He need a RUN!";
        notification.FireTime = System.DateTime.Now.AddHours(6);                //AddHours(8); //AddSeconds(10);


        //Invio della notifica
        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        //Se lo script manda un messaggio gia schedato cancella e ri schedula un altro

        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
