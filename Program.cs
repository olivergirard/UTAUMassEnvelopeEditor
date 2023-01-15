using utauPlugin;
using UtauVoiceBank;
using Wave;

namespace MassEnvelopeEditor
{
    class Program
    {

        static bool isNoteFirstInRegion = true;

        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();

            string firstEnvelope = null;

            /* Iterating through each note, selected or unselected, in the .ust. */

            foreach (Note note in utauPlugin.note)
            {

                if (IsSelected(note) == true)
                {
                    if (firstEnvelope == null)
                    {
                        firstEnvelope = note.GetEnvelope();
                    }

                    /* This will not reset preutterance and overlap values. */

                    note.SetEnvelope(firstEnvelope);
                }
            }

            utauPlugin.Output();
        }
        static bool IsSelected(Note note)
        {
            /* The selected region includes the unselected note immediately before the selected region.*/

            if ((note.GetRegion() != null) && (isNoteFirstInRegion == false))
            {
                return true;
            } else
            {
                isNoteFirstInRegion = false;
                return false;
            }

        }
    }
}