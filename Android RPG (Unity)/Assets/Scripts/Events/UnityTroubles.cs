using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTroubles : StoryEvent
{
    public override string ChaFail2()
    {
        return "Unfortunately your words fall on deaf ears as the program only begins to output more errors. Your patience breaks in frustration and you defeatadly abandon the project.";
    }

    public override string ChaOption2()
    {
        return "Vent your frustrations to the project about its lack of cooperation";
    }

    public override string ChaPass2()
    {
        return "Despite involving no computer technique whatsoever, venting about Unity made the errors go away! Strangely, you see yourself in the now-running project, contemplating what to do against a Unity project with errors. " +
            "You think little of it and move on.";
    }

    public override void Debugger()
    {
        Debug.Log("Unity Troubles");
    }

    public override string DexFail3()
    {
        return "No matter how far you run, the Unity errors keep coming after you. Around every corner, in every bush, every time you close your eyes, you see them. Sadly it seems, you can't run fast enough to escape your past errors.";
    }

    public override string DexOption3()
    {
        return "Circumnavigate the problem by running from it really fast (like you do all of life's troubles)";
    }

    public override string DexPass3()
    {
        return "Without even a thought you bolt down the path as far as you can, leaving everything behind you. Maybe you'd feel a smidge of regret but you leave that feeling behind you, too.";
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

    public override string NarrativeStart()
    {
        return "You're walking a long a path and a wild Unity project error appears! You try to ignore it but it blocks your path.";
    }

    public override string StrOption0()
    {
        return "Punch that program out of existence";
    }

    public override string WisOption1()
    {
        return "Use your elite programming skills to solve the issue";
    }

    public override string StrPass0()
    {
        return "Using your hand like a brick you smash that computer screen to bits and suddenly the error window is gone! Success! You continue forwarding knowing the errors are gone (you clearly don't think too hard about it.)";
    }

    public override string StrFail0()
    {
        return "Using all your strength you punch the lights out of the monitor, but in a dark twist the errors fly out like bats and start chasing you in the real world! You high-tail it down the path frightened and scared as you " +
            "try to lose them.";
    }

    public override string WisPass1()
    {
        return "It's quite obvious after a brief thought what the errors are! You know the ones I'm talking about. In retrospect, you wonder how they ever could've been so difficult to fix. They're easy peasy and you go on feeling " +
            "satisfied, just like every programmer in this room! (Right?)";
    }

    public override string WisFail1()
    {
        return "Despite your elite computer skills you're unable to solve the fix. You Google search every possible thing you can think of and try it all, only to find yourself with more errors than before. You hang your head and shame" +
            "and continue on, leaving the poor program in error-limbo for another time.";
    }
}

    

