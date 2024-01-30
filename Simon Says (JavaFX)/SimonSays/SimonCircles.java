package SimonSays;


import javafx.scene.shape.Circle;

public class SimonCircles extends Circle{
	private static int circleIndexCounter = 0;
	private int circleIndex;
	
	public SimonCircles(double x, double y, double radius){
		super(x, y, radius);
		this.circleIndex = this.circleIndexCounter;
		circleIndexCounter++;
	}
	
	public int getCircleIndex(){
		return this.circleIndex;
	}
	
}
