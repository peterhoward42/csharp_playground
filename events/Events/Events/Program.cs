using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            new App().run();
        }
    }


    class App
    {
        // A method that we will route events to
        void handlerFn(object sender, EventArgs e)
        {
            Debug.Print("Received this event <{0}>", e.ToString());
        }

        public void run()
        {
            // instantiate a thing that can emit events
            var emittingThing = new EventEmittingThing();

            // subscribe to the emitted events
            emittingThing.fooEvent += this.handlerFn;

            // stimulate event firing
            emittingThing.shouldStimulateEmission();
        }
    }

    public class EventEmittingThing
    {
        // Publish a type for the event emitted
        public delegate void HandlePeteEvents(object sender, EventArgs e);

        // Have an emitting field
        public event HandlePeteEvents fooEvent;

        public void shouldStimulateEmission()
        {
            fooEvent(this, EventArgs.Empty);
        }
    }
}
