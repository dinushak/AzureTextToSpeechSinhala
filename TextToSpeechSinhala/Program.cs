using Microsoft.CognitiveServices.Speech;

class Program
{
    static async Task Main(string[] args)
    {
        do
        {
            await Speak();
            Console.WriteLine("Next Number");
            Console.ReadLine();
        } while (true);
    }


    static async Task Speak()
    { 
    
        Random random = new Random();
        var counter = random.Next(1,5);
        var token = random.Next(100, 500);

        var config = SpeechConfig.FromSubscription("0f018c844c7046be835c444f0937d3f4", "eastus");
        config.SpeechSynthesisVoiceName = "si-LK-ThiliniNeural";


        using var synth = new SpeechSynthesizer(config);

        Console.WriteLine(counter);
        Console.WriteLine(token);

        var result = await synth.SpeakTextAsync("ටෝකන් අංකය " + token + "දරන පාරිභෝගිකයා, කරුණාකර කවුළු අංකය " +counter + "වෙත පැමිණෙන්න ");

        if (result.Reason != ResultReason.SynthesizingAudioCompleted)
        {
            Console.WriteLine(result.Reason);
        }
        else
        {
            Console.WriteLine("Completed");
        }
    }

}