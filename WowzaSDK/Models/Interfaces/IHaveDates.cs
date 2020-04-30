using System;
namespace WowzaSDK.Models.Interfaces
{
    public interface IHaveDates
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
