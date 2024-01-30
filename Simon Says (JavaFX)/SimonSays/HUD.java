package SimonSays;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Pos;
import javafx.scene.input.MouseEvent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.BorderPane;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.text.Text;
import javafx.scene.control.Button;
import javafx.scene.layout.GridPane;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import java.util.ArrayList;
import javafx.animation.FadeTransition;
import javafx.animation.Timeline;
import javafx.util.Duration;

public class HUD extends Application{
	
	private BorderPane simonsPane = new BorderPane();
	private BorderPane playersPane = new BorderPane();
	private GridPane textDisplayer = new GridPane();
	private GridPane infoPane = new GridPane();
	private BorderPane rootPane = new BorderPane();
	private Button start = new Button("Start");
	private TextField roundMessage = new TextField("Empty");
	private static TextField score = new TextField("Score : ");
		
	public void start(Stage primaryStage) {
			
		simonsPane = instantiateSimonsPane(simonsPane);
		playersPane = instantiatePlayersPane(playersPane);
		instantiateTextDisplayer();
		instantiateInfoPane();
		instantiateRootPane();
		Scene scene = new Scene(rootPane, 600, 200);
		primaryStage.setTitle("Simon Says");
		primaryStage.setScene(scene);
		primaryStage.show();	
	}
		
	public void instantiateTextDisplayer() {
		
		roundMessage.setEditable(false);
		this.textDisplayer.getChildren().add(roundMessage);
		
	}
	
	public void instantiateInfoPane() {
		this.start.setLayoutX(500);
		this.start.setLayoutY(50);
		this.infoPane.getChildren().add(this.start);
		this.infoPane.setRowIndex(this.start, 0);
		this.infoPane.setColumnIndex(this.start, 0);
		this.infoPane.getChildren().add(this.score);
		this.infoPane.setRowIndex(this.score, 1);
		this.infoPane.setColumnIndex(this.score, 0);
		
		this.start.setOnAction(e -> startGame());
	}
	
	public void instantiateRootPane() {

		this.rootPane.setLeft(this.simonsPane);
		this.rootPane.setTop(this.playersPane);
		this.rootPane.setRight(this.infoPane);
		this.rootPane.setBottom(this.textDisplayer);
	}
	
	public BorderPane instantiatePlayersPane(BorderPane playersPane) {
		
		SimonSays.instantiateBoard();
		
		Text player = new Text(313, 20, "Player");
		
		playersPane.getChildren().add(player);
		

		
		SimonCircles[][] board = SimonSays.getBoard();
		
		addClickables();
		
		for(int i = 0; i < SimonSays.CIRCLE_NO; i++) {
			playersPane.getChildren().add(board[SimonSays.playerIndex][i]);
		}
		
		return playersPane;
		
	}
	
	public BorderPane instantiateSimonsPane(BorderPane simonsPane) {
		
		SimonSays.instantiateBoard();
		
		Text simon = new Text(90, 20, "Simon");
		
		simonsPane.getChildren().add(simon);
			
		SimonCircles[][] board = SimonSays.getBoard();
		for(int i = 0; i < SimonSays.CIRCLE_NO; i++) {
			
			simonsPane.getChildren().add(board[SimonSays.simonIndex][i]);
		}
		
		
		return simonsPane;
		
	}
	
	public void addClickables() {
		 
		SimonCircles[][] board = SimonSays.getBoard();
		
		for(int j = 0; j < SimonSays.CIRCLE_NO; j++) {
			final int tempJ = j;
			board[SimonSays.PLAYER_NO - 1][j].setOnMouseClicked(e -> SimonSays.simonCheck(board[SimonSays.PLAYER_NO - 1][tempJ]));
		}
		
		
	}
	
	public void startGame() {
		roundMessage.setText("You did it");
		SimonSays.startGame();
	}
	
	public static void updateScore(int newScore) {
		if(SimonSays.isSimonPlaying() == false) {
			score.setText("Score:" + newScore);
		}
	}
	
	public static void simonDisplay(ArrayList<Integer> simonSays) {
		
		for(int i = 0; i < simonSays.size(); i++) {
			//SimonSays.getBoardIndex(simonSays.get(i)).setOpacity(.5);
			FadeTransition ft = new FadeTransition(Duration.millis(1000), SimonSays.getBoardIndex(simonSays.get(i)));
			System.out.println("Fading + " + i + ": " + simonSays.get(i));
			 	ft.setFromValue(1.0);
			    ft.setToValue(0.1);

			    ft.setCycleCount(Timeline.INDEFINITE);
		    ft.play();
		    System.out.println("Fade time");
		    
		    SimonSays.getBoardIndex(simonSays.get(i)).setFill(Color.BLACK);
		}
		
	}
	
	
	public static void main(String[] args) {
		launch(args);
	}
	
}
