using ChallengeDotNET.Models;

try
{
    User user = new User(1000);
    DateTime dateTimeWhenPasswordCreated = DateTime.Now;

    user.Password.Value = user.Password.GenerateOneTimePassword(user.UserId, dateTimeWhenPasswordCreated);

    Console.WriteLine(user.Password.Value);
    Console.WriteLine(user.Password.IsValid);

    await Task.Delay(TimeSpan.FromSeconds(30.1));
    Console.WriteLine(user.Password.Value);
    Console.WriteLine(user.Password.IsValid);
}
catch (Exception e)
{
    Console.WriteLine(e);
}