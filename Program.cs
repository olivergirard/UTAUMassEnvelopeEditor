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

            Note firstNote = new Note();
            bool copiedEnvelope = false;

            foreach (Note note in utauPlugin.note)
            {
                /* if the note is part of a selected range */

                if (IsSelected(note) == true)
                {
                    if (copiedEnvelope == false)
                    {
                        firstNote = note.Next;
                        copiedEnvelope = true;
                    } else
                    {
                        note.SetEnvelope(firstNote.GetEnvelope());
                    }
                }
            }

            utauPlugin.Output();
        }
        static bool IsSelected(Note note)
        {
            if (note.GetRegion() != null)
            {
                return true;
            } else
            {
                return false;
            }

        }
    }
}