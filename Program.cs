using utauPlugin;
using UtauVoiceBank;
using Wave;

namespace MassEnvelopeEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();

            foreach (Note note in utauPlugin.note)
            {
                note.SetEnvelope((utauPlugin.note[0]).GetEnvelope());
            }

            utauPlugin.Output();
        }
    }
}