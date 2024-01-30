package SimonSays;

import javafx.scene.paint.Color;
import java.util.ArrayList;
import java.util.Random;

public class SimonSays {

	static final int CIRCLE_NO = 3;
	static final int PLAYER_NO = 2;
	private static SimonCircles[][] board;
	private static ArrayList<Integer> simonSays = new ArrayList<>();
	private static ArrayList<Integer> playerSays = new ArrayList<>();
	private static Boolean hasWon;
	private static int score;
	private static int hiScore;
	public static int simonIndex = 0;
	public static int playerIndex = 1;
	private static Boolean simonPlaying;
	
	
	public static void instantiateBoard(){
		board = new SimonCircles[PLAYER_NO][CIRCLE_NO];
		
		final double RAD = 25;
		final double YVAL = 70;
		final double XVAL = 55;
		int xValMultiplier = 1;
		
		
		for(int i = 0; i < PLAYER_NO; i++) {
			for(int j = 0; j < CIRCLE_NO; j++) {
				
				if(i == 1 && j == 0) {
					xValMultiplier += 1;
				}
				
				board[i][j] = new SimonCircles( (xValMultiplier * XVAL) , YVAL, RAD);
				xValMultiplier += 1;
			}
		}
		
		setColors();
		
	}

	public static SimonCircles[][] getBoard(){
		
		return board;
	}
	public static void setColors(){
		
		for(int i = 0; i < PLAYER_NO; i++) {
			
			board[i][0].setFill(Color.RED);
			board[i][1].setFill(Color.BLUE);
			board[i][2].setFill(Color.GREEN);
			
			board[i][0].setStroke(Color.RED);
			board[i][1].setStroke(Color.BLUE);
			board[i][2].setStroke(Color.GREEN);
			
		}
		
		
	}
	
	public static SimonCircles getBoardIndex(int index){
		return board[0][index];
	}
	
	public static void simonCheck(SimonCircles circle) {
		if(circle.getCircleIndex() > -1) {
			increaseScore();
		}
	}
	
	public static void increaseScore() {
		score++;
		HUD.updateScore(score);
	}
	
	public static void startGame() {
		
		hasWon = true;
		while(hasWon != false) {
			
			for(int rounds = 1; hasWon != false; rounds++) {
				int randCircle = getRandCircle();
				simonSays.add(randCircle);
				simonTurn();
				hasWon = playerTurn();
				if(hasWon == true) {
					increaseScore();
					hasWon = false;
				}
			}
		}
		
	}
	
	private static int getRandCircle() {
		Random rand = new Random();
		int randCircleIndex = rand.nextInt(CIRCLE_NO);
		return randCircleIndex;
	}
	
	public static void simonTurn() {
		simonPlaying = true;
		HUD.simonDisplay(simonSays);
		simonPlaying = false;
	}
	
	public static Boolean isSimonPlaying() {
		return simonPlaying;
	}
	
	public static Boolean playerTurn() {
		return true;
	}
	
	
	
	
}
