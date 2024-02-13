using System;
using System.IO;

class Program
{
	static int NewPosition(
		int currentPosition, 
		int move, 
		int n, 
		ref bool positionIsSet, 
		ref int distance)
	{
		if (positionIsSet)
			distance += Math.Abs(move);
		
		positionIsSet = true;
		
		int newPosition = currentPosition + move;

		if (newPosition > n)
			newPosition -= n;
		else if (newPosition < 0)
			newPosition += n;

		return newPosition;
	}

	static string GameState(int mousePos, int catPos, bool mousePosIsSet, bool catPosIsSet)
	{
		string gameState = "";

		gameState += catPosIsSet ? $"{catPos}\t" : "??\t";
		gameState += mousePosIsSet ? $"{mousePos}\t" : "??\t";

		if (catPosIsSet && mousePosIsSet)
			gameState += $"{catPos > mousePos ? catPos - mousePos : mousePos - catPos}";

		return gameState;
	}

	static void Main()
	{
		int mousePosition = 0;
		int catPosition = 0;

		bool mousePositionIsSet = false;
		bool catPositionIsSet = false;

		int mouseDistance = 0;
		int catDistance = 0;

		bool mouseIsCaught = false;

		Console.Write("Введите номер используемого файла:\n> ");
		string fileNumber = Console.ReadLine();

		var sr = new StreamReader($"./txt/ChaseData_{fileNumber}.txt");
		var file = new FileStream($"./txt/PursuitLog_{fileNumber}.txt", FileMode.OpenOrCreate);
		var sw = new StreamWriter(file);
		
		int n = int.Parse(sr.ReadLine());

		sw.WriteLine("Cat and Mouse\n");
		const string header = "Cat\tMouse\tDistance";
		sw.WriteLine($"{header}\n{new string('-', header.Length)}");

		while (!sr.EndOfStream)
		{
			string line = sr.ReadLine();
			string command = line.Substring(0, 1);

			if (command.Equals("P"))
			{
				sw.WriteLine(GameState(mousePosition, catPosition, mousePositionIsSet, catPositionIsSet));
			}
			else
			{
				int move = int.Parse(line.Substring(1));

				switch (command)
				{
					case "C":
						catPosition = NewPosition(catPosition, move, n, ref catPositionIsSet, ref catDistance);
						break;
					case "M":
						mousePosition = NewPosition(mousePosition, move, n, ref mousePositionIsSet, ref mouseDistance);
						break;
				}
			}

			if (catPosition == mousePosition)
			{
				mouseIsCaught = true;
				break;
			}
		}

		sw.WriteLine($"{new string('-', header.Length)}\n");
		sw.WriteLine($"Distance traveled:\tMouse\tCat\n\t\t\t{mouseDistance}\t{catDistance}\n");
		sw.WriteLine($"{mouseIsCaught ? $"Mouse caught at: {mousePosition}" : "Mouse evaded Cat"}");

		sw.Close();
		sr.Close();
	}
}
