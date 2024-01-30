package simonSays;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;    

//this abstract class is responsible for writing scores and the date they were achieved to a file
public abstract class WriteToFile{
	
	//our Objects for the file and printing out to the file
	private static File scoreList;
	private static PrintWriter pw;
	
	//this method takes an int (a score) and will write it, as well as the timestamp of achievement to the file
	public static void writeScoreToFile(int score) throws IOException {
		
		//the following two Objects set a formatter for the time stamp and grabs the current time when called
		DateTimeFormatter timeStamp = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");  
		LocalDateTime scoreAchieved = LocalDateTime.now();  
		
		//this string is what will be printed to the file
		String scoreString = "Score of " + score + " achieved: " + timeStamp.format(scoreAchieved) + "\n";  
		
		//sets our File object scoreList to grab our scores.txt file
		scoreList = new File("scores.txt");
		
		//try/exception handler for IOExceptions
		try{
			
			//if statement that creates a new file should scores.txt somehow be deleted
			if(scoreList.exists() == false){
				System.out.println("File not found; creating new file");
				scoreList.createNewFile();
			}
		
			//instantiate the PrintWriter to a FileWriter containing our File scoreList and setting it to add and not replace
			pw = new PrintWriter(new FileWriter(scoreList, true));
			
			//append the String to the end of the file
			pw.append(scoreString);
			
			//close the file
			pw.close();
			
		}catch (IOException e){
			
			//if we catch an IOException, print out the bug to the System
			System.out.println("Cannot write to file");
		}
		
	}
	
}
