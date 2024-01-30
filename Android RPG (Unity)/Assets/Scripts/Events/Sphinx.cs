using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphinx : StoryEvent
{
    // all story events have their "stat methods" ending with the proper stat index in the Variables file
    public override void Debugger()
    {
        Debug.Log("Sphinx");
    }

    public override string NarrativeStart()
    {
        return "You make your way to a bridge but a sphinx blocks the road. She tells your she'll let you pass if you answer her riddle.";
    }

    public override string StrOption0()
    {
        return "Use your mass strength to move the sphinx out of the way";
    }

    public override string WisOption1()
    {
        return "Make a test of wits and accept the challenge";
    }

    public override string ChaOption2()
    {
        return "Convince her you really need to cross the bridge and don't have time for games!";
    }

    public override string DexOption3()
    {
        return "Leave briefly and try to sneak around the sphinx";
    }

    public override string StrPass0()
    {
        return "In a moment of panic the sphinx shrieks as you easily toss her over the bridge. You walk past her sitting post as she falls over dazed.";
    }

    public override string StrFail0()
    {
        return "Your bravery turns out to be stupidity as the ten times as tall sphinx swipes you off the path. Bruised and broken, you take a detour.";
    }

    public override string WisPass1()
    {
        return "The sphinx asks, 'What starts with E, ends with E, and has but one letter in it?' You smile and speak, 'An Envelope, of course!' The sphinx has no choice but to let you pass as you continue with a smile.";
    }

    public override string WisFail1()
    {
        return "The sphinx asks, 'What is your favorite colour?' Unfortunately, startled, you instead blabble about Europian swallows. Unsurprisngly, she doesn't let you through. As you take the long route around, " +
            "you're at least thankful the sphinx claimed she was a vegan.";
    }

    public override string ChaPass2()
    {
        return "Using a bit of that rugged charm of yours, you flatter the sphinx enough to convince her your mission is important. She even leaves you her number. Sweet!";
    }

    public override string ChaFail2()
    {
        return "Unfortunately the sphinx has no time for shenanigans like yours. She yawns at your inquiry and begins to sleep on the path, unable to be awoken. You begrundingly walk around the long way.";
    }

    public override string DexPass3()
    {
        return "With a bit of swiftness and playing out of vision, you manage to sneak onto the bridge right around the sphinx. She is none the wiser.";
    }

    public override string DexFail3()
    {
        return "Though you try your best to sneak around, your lame attempts at hiding behind objects is revealed when the sphinx catches you sneaking behind a groundhog. Angered, she starts coming after you and you " +
            "elect to run for your life, which happens to be the long way around the bridge.";
    }

    public override string GetStatText(int i)
    {

        if (i == 0)
        {
            return StrOption0();
        }
        else if (i == 1)
        {
            return WisOption1();
        }
        else if (i == 2)
        {
            return ChaOption2();
        }
        else
        {
            return DexOption3();
        }
    }

    public override string GetStatPass(int i)
    {
        if (i == 0)
        {
            return StrPass0();
        }
        else if (i == 1)
        {
            return WisPass1();
        }
        else if (i == 2)
        {
            return ChaPass2();
        }
        else
        {
            return DexPass3();
        }
    }

    public override string GetStatFail(int i)
    {
        if (i == 0)
        {
            return StrFail0();
        }
        else if (i == 1)
        {
            return WisFail1();
        }
        else if (i == 2)
        {
            return ChaFail2();
        }
        else
        {
            return DexFail3();
        }
    }
}
