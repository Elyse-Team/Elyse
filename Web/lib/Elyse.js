var Elyse = function(options){
	this.stage = new PIXI.Stage(0xFFFFFF);
	this.renderer = PIXI.autoDetectRenderer(1600, 900, null, true);
	this.container = options.container || document.getElementsByTagName('body')[0];
	this.debug = options.debug || false;

	this.container.appendChild(this.renderer.view);

	//							 THE GRID 					   
	//														   
	//		 ______________________1600_______________________ 
	//		|0,0      |320,0    |640,0    |960,0    |1280,0   |
	//		|         |         |         |         |         |
	//		|         |         |         |         |         |
	//		|         |         |         |         |         |
	//	   9|         |         |         |         |         |
	//	   0|_________|_________|_________|_________|_________|
	//	   0|0,450    |320,450  |640,450  |960,450  |1280,450 |
	//		|         |         |         |         |         |
	//		|         |         |         |         |         |
	//		|         |         |         |         |         |
	//		|         |         |         |         |         |
	//		|_________|_________|_________|_________|_________|
	//														   
	//														    

	//Print the grid
	if(this.debug){
		var grid = new PIXI.Graphics();
		grid.lineStyle(1, 0xFF0000);
		grid.drawRect(0, 0, 960, 900);
		grid.drawRect(320, 0, 960, 900);
		grid.drawRect(640, 0, 960, 900);
		grid.drawRect(0, 0, 1600, 450);
		this.stage.addChild(grid)
	}

}

Elyse.prototype.setBackground = function(background){

}

Elyse.prototype.addCharacter = function(options){
	return new Elyse.Character(this.stage, options);
}

Elyse.textures = [];
Elyse.loadSprite = function(image){
	image = './assets/img/' + image;
	Elyse.textures[image] = Elyse.textures[image] || PIXI.Texture.fromImage(image);
	return new PIXI.Sprite(Elyse.textures[image]);
}



//Entities orientation
Elyse.orientation = {
	LEFT : 1,
	RIGHT : -1
};


Elyse.animations = [];
Elyse.addAnimation = function(options){
	e = {};
	e.start = +new Date;
	e.type = options.type;
	e.ms = options.ms;
	e.el = options.el;
	e.init = options.init;
	e.target = options.target;
	e.diff = {};
	if(e.init){
		for(var attr in e.init){
		e.diff[attr] = e.target[attr]-e.init[attr];
	}
	}	
	e.callback = options.callback;
	Elyse.animations.push(e);
}
Elyse.animate = function(){
	var now = +new Date,
		i = Elyse.animations.length,
		e,	//animation
		dt,	//elapsed time
		percent; 

	while(i-->0){
		e = Elyse.animations[i];
		if(!e) continue;
		dt = now - e.start;
		percent = dt/e.ms;
		if(e.ms < dt) {
			if(e.callback) e.callback();
			delete Elyse.animations[i];
		}
		switch(e.type){
			case 'transform':
				for(var attr in e.diff){
					e.el[attr] = e.init[attr] + e.diff[attr] * percent;
				}
			break;
			case 'talk':

			break;
		}
	}

}


window.requestAnimationFrame = 	window.requestAnimationFrame || 
								window.mozRequestAnimationFrame ||
                              	window.webkitRequestAnimationFrame || 
                              	window.msRequestAnimationFrame;

Elyse.prototype.run = function(){
	Elyse.animate();
	requestAnimationFrame(this.run.bind(this));
	this.renderer.render(this.stage);
}