namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string GuestName;
    public string RoomNumber;
    public DateTime CheckInDate;
    public DateTime CheckOutDate;
    public int TotalDays;
    public double RatePerDay;
    public double Discount;
    public double TotalAmount;

    public async Task BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkin;
        CheckOutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        TotalDays = (checkout - checkin).Days;
        
        double basePrice = TotalDays * RatePerDay;
        TotalAmount = basePrice - (basePrice * Discount / 100);

        await LogBookingDetailsAsync();

        Console.WriteLine("--- Booking Details ---");
        Console.WriteLine("Room Booked for: " + GuestName);
        Console.WriteLine("Room No: " + RoomNumber);
        Console.WriteLine("Check-In: " + CheckInDate.ToShortDateString());
        Console.WriteLine("Check-Out: " + CheckOutDate.ToShortDateString());
        Console.WriteLine("Total Days: " + TotalDays);
        Console.WriteLine("Total Amount: " + TotalAmount);
    }

    public async Task LogBookingDetailsAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        GuestName = "";
        RoomNumber = "";
        TotalAmount = 0;
        Console.WriteLine("Booking cancelled");
    }
}

public static class AppHost
{
    static async Task Main(string[] args)
    {
        Booking b = new Booking();
        
        await b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        
        b.Cancel();
    }
}