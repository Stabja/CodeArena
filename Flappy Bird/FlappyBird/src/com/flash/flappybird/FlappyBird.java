package com.flash.flappybird;

import java.util.Iterator;

import com.badlogic.gdx.ApplicationListener;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.MathUtils;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector3;
import com.badlogic.gdx.utils.Array;
import com.badlogic.gdx.utils.TimeUtils;

public class FlappyBird implements ApplicationListener {
	
	private OrthographicCamera camera;
	private SpriteBatch batch;
	
	private Texture birdImage;
	private Texture pipeBottomImage;
	private Texture pipeTopImage;
	private Texture background;
	
	private Sound dropSound;
	private Sound beepSound;
	
	private Rectangle bird;
	private Array<Rectangle> pipeBottom;
	private Array<Rectangle> pipeTop;
	private long lastTime;
	
	private static final double jumpVelocity = 7.5;
	
	private static final int pipeWidth = 50;
	private static final int pipeHeight = 350;
	private static final int gap = 80;
	private static final int birdWidth = 30;
	private static final int birdHeight = 20;
	private static double birdVel = 0;
	private static double birdAccel = 0.44;
	private static double jumpVel = jumpVelocity;
	private static double jumpAccel = 0.44;
	
	private static final int pipeSpeed = 120;
	
	private boolean jumpComplete = true;
	private boolean birdDie = false;
	private boolean pressed = false;
	
	private int score = 0;
	
	@Override
	public void create() {		
		//float w = Gdx.graphics.getWidth();
		//float h = Gdx.graphics.getHeight();
			
		birdImage = new Texture(Gdx.files.internal("bird.png"));
		pipeBottomImage = new Texture(Gdx.files.internal("bottom.png"));
		pipeTopImage = new Texture(Gdx.files.internal("top.png"));
		background = new Texture(Gdx.files.internal("background.png"));
			
	    dropSound = Gdx.audio.newSound(Gdx.files.internal("drop.wav"));
	    beepSound = Gdx.audio.newSound(Gdx.files.internal("beep.mp3"));	
		
		camera = new OrthographicCamera();
	    camera.setToOrtho(false, 800, 480);
	    batch = new SpriteBatch();
		
		bird = new Rectangle();
		bird.x = 200;
		bird.y = 240;
		bird.width = birdWidth;
		bird.height = birdHeight;
		
		pipeBottom = new Array<Rectangle>();
		pipeTop = new Array<Rectangle>();
		spawnPipe();
		
	}
	
	public void spawnPipe(){
		
		Rectangle bottom = new Rectangle();
		bottom.x = 800;
		bottom.y = MathUtils.random(-300, 0);
		bottom.width = pipeWidth;
		bottom.height = pipeHeight;
		
		Rectangle top = new Rectangle();
		top.x = 800;
		top.y = bottom.y + pipeHeight + gap + 40;
		top.width = pipeWidth;
		top.height = pipeHeight;
		
		pipeBottom.add(bottom);
		pipeTop.add(top);
		
		lastTime = TimeUtils.nanoTime();
		
	}

	

	@Override
	public void render() {		
		Gdx.gl.glClearColor(0, 0, 0.2f, 1);
	    Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
	     
		camera.update();
		batch.setProjectionMatrix(camera.combined);
		
		batch.begin();
		batch.draw(background, 0, 0);
		for(Rectangle bottom : pipeBottom){     batch.draw(pipeBottomImage, bottom.x, bottom.y);   }
		for(Rectangle top : pipeTop){           batch.draw(pipeTopImage, top.x, top.y);            }
		batch.draw(birdImage, bird.x, bird.y);
		batch.end();
		
		if(jumpComplete){
			bird.y -=birdVel;
			birdVel += birdAccel;
		}
		
		if((Gdx.input.isTouched() || Gdx.input.isKeyPressed(Keys.SPACE)) && pressed == false && !birdDie){
			pressed = true;
			jumpComplete = false;
			dropSound.play();
			jumpVel = jumpVelocity;                                             //Remember to change this			
	        Vector3 touchPos = new Vector3();
	        touchPos.set(Gdx.input.getX(), Gdx.input.getY(), 0);
	        camera.unproject(touchPos);	         
	        
	    }
		if(!Gdx.input.isKeyPressed(Keys.SPACE))  pressed = false;
		
		
		//if(Gdx.input.isKeyPressed(Keys.SPACE))  jumpComplete = false;
		
		if(jumpComplete == false)   jumpBird();
		
		if(bird.y < 0)   bird.y = 0;                      //Donot render the bird outside the screen
	    if(bird.y > 480 - 20) bird.y = 480 - 20;          //Donot render the bird outside the screen
		
	    if(TimeUtils.nanoTime() - lastTime > 1600000000) spawnPipe();
	    
	    checkCollision();
		
	}
	
	public void checkCollision(){
		
		Iterator<Rectangle> bottomIter = pipeBottom.iterator();
		Iterator<Rectangle> topIter = pipeTop.iterator();
		
	      while(bottomIter.hasNext() && topIter.hasNext()) {
	    	  
	         Rectangle bot = bottomIter.next();
	         Rectangle to = topIter.next();
	         
	         if(birdDie == false){
	             bot.x -= pipeSpeed * Gdx.graphics.getDeltaTime();  //Move the pipes
	             to.x -= pipeSpeed * Gdx.graphics.getDeltaTime();   //Move the pipes
	         }
	         
	         //System.out.println(score);
	         
	         if( bot.x > bird.x-1 && bot.x < bird.x + 1){      
	        	 beepSound.play();
	        	 score++;
	        	 System.out.println(score);
	         }
	         
	         if(bot.x < -50) bottomIter.remove();          //Donot render the pipe outside the screen
	         if(to.x < -50) topIter.remove();              //Donot render the pipe outside the screen
	         
	         if(bot.overlaps(bird) || to.overlaps(bird)){       //If collision occurs	        	     	 
	        	 dieBird();      
	         }
	      }
	      
	}
	
	public void dieBird(){
		birdDie = true;
	}
	
	public void jumpBird(){
		
		bird.y += jumpVel;
		jumpVel -= jumpAccel;
		if(jumpVel == 0)
		{
			jumpVel = jumpVelocity;
			jumpComplete = true;
		}
		
	}

	@Override
	public void dispose() {
		
		birdImage.dispose();
		pipeBottomImage.dispose();
		pipeTopImage.dispose();
		background.dispose();
		dropSound.dispose();
		beepSound.dispose();
		batch.dispose();
	}
	
	@Override
	public void resize(int width, int height) {
	}

	@Override
	public void pause() {
	}

	@Override
	public void resume() {
	}
}