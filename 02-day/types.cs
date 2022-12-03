namespace Types;

public enum Choice
{
    Rock,
    Paper,
    Scissors
}

public class ChoiceMapper
{
    Dictionary<string, Choice> themMap = new Dictionary<string, Choice>()
    {
        {"A", Choice.Rock},
        {"B", Choice.Paper},
        {"C", Choice.Scissors}
    };

    Dictionary<string, Choice> meMap = new Dictionary<string, Choice>()
    {
        {"X", Choice.Rock},
        {"Y", Choice.Paper},
        {"Z", Choice.Scissors}
    };

    Dictionary<string, int> resultMap = new Dictionary<string, int>()
    {
        {"X", 0},
        {"Y", 3},
        {"Z", 6}
    };

    public Choice mapThem(string choice)
    {
        return themMap[choice];
    }

    public Choice mapMe(string choice)
    {
        return meMap[choice];
    }

    public int mapResult(string choice)
    {
        return resultMap[choice];
    }

    public int getResultPoints(Choice them, Choice me)
    {
        if (them == me) return 3;
        if (them == Choice.Rock && me == Choice.Scissors) return 0;
        if (them == Choice.Paper && me == Choice.Rock) return 0;
        if (them == Choice.Scissors && me == Choice.Paper) return 0;
        return 6;
    }

    public int getSelectionPoints(Choice me)
    {
        if (me == Choice.Rock) return 1;
        if (me == Choice.Paper) return 2;
        if (me == Choice.Scissors) return 3;
        throw new System.ArgumentException("Invalid choice");
    }

    public Choice getChoiceForResult(Choice them, string result)
    {
        if (result == "Y") return them;
        if (them == Choice.Rock && result == "X") return Choice.Scissors;
        if (them == Choice.Paper && result == "X") return Choice.Rock;
        if (them == Choice.Scissors && result == "X") return Choice.Paper;
        if (them == Choice.Rock && result == "Z") return Choice.Paper;
        if (them == Choice.Paper && result == "Z") return Choice.Scissors;
        if (them == Choice.Scissors && result == "Z") return Choice.Rock;
        else throw new System.ArgumentException("Invalid choice");
    }
}