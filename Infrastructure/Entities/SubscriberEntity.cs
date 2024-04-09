using Infrastructure.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscriberEntity
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Email", Prompt = "Your Email")]
    public string Email { get; set; } = null!;


    //public bool DailyNewsletter { get; set; }


    //public bool AdvertisingUpdates { get; set; }


    //public bool WeekinReview { get; set; }


    //public bool EventUpdates { get; set; }


    //public bool StartupsWeekly { get; set; }

    //public bool Podcasts { get; set; }

    //public static implicit operator SubscriberEntity(SubscribeRegistrationForm form)
    //{
    //    return new SubscriberEntity
    //    {
    //        Email = form.Email,
    //        DailyNewsletter = form.DailyNewsletter,
    //        AdvertisingUpdates = form.AdvertisingUpdates,
    //        WeekinReview = form.WeekinReview,
    //        EventUpdates = form.EventUpdates,
    //        StartupsWeekly = form.StartupsWeekly,
    //        Podcasts = form.Podcasts,
    //    };
    //}
}
