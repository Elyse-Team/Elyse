Elyse.Character = function(stage, options){
	this.name = options.name;
	this.head = options.head || 'smile';
	this.body = options.body || 'blue';

	this.sprites = {
		head : Elyse.loadSprite(Elyse.Character.heads[this.head].path),
		body : Elyse.loadSprite(Elyse.Character.bodies[this.body].path)
	};

	this.sprites.head.scale.x = Elyse.Character.heads[this.head].scale;
	this.sprites.head.scale.y = Elyse.Character.heads[this.head].scale;
	this.sprites.body.scale.x = Elyse.Character.bodies[this.body].scale;
	this.sprites.body.scale.y = Elyse.Character.bodies[this.body].scale;
	this.sprites.head.position = new PIXI.Point(Elyse.Character.heads[this.head].dx,Elyse.Character.heads[this.head].dy);
	this.sprites.body.position = new PIXI.Point(Elyse.Character.bodies[this.body].dx,Elyse.Character.bodies[this.body].dy);
	this.displayObject = new PIXI.DisplayObjectContainer();
	this.displayObject.addChild(this.sprites.head);
	this.displayObject.addChild(this.sprites.body);


	this.orientation = options.orientation || Elyse.orientation.LEFT;

	this.displayObject.x = ((options.x-this.displayObject.width)/2) || (320-this.displayObject.width)/2;
	this.displayObject.y = (options.y-this.displayObject.height) || (450-this.displayObject.height);


	Object.defineProperty(this, "x", {
    	get: function() { return this.displayObject.x; },
    	set: function(value) { this.displayObject.x = value}
  	});

  	Object.defineProperty(this, "y", {
    	get: function() { return this.displayObject.y; },
    	set: function(value) { this.displayObject.y = value}
  	});


  	this.isMoving = false;
  	this.target = {
  		x : this.x,
  		y : this.y
  	}


	stage.addChild(this.displayObject);
}

//Consts

Elyse.Character.heads = {
	smile : {
		path : 'smile.png',
		dx : 0,
		dy : 0,
		scale : 0.5
	}
}

Elyse.Character.bodies = {
	blue : {
		path : 'body-blue.png',
		dx : 30,
		dy : 180,
		scale : 0.7
	}
}


Elyse.Character.prototype.move = function(x, y, ms, callback){
	Elyse.addAnimation({
		el : this,
		type : 'transform',
		ms : ms || 3000,
		init : {
			x : this.x,
			y : this.y
		},
		target : {
			x : x ,
			y : y 
		},
		callback : callback
	});
	console.log(x,y)
	return this;
}

Elyse.Character.prototype.lookAt = function(orientation){
	this.displayObjectContainer.scale(this.orientation = orientation);
	return this;
}

Elyse.Character.prototype.turnBack = function(){
	if(this.orientation === Elyse.orientation.LEFT){
		this.lookAt(Elyse.orientation.RIGHT);
	} else {
		this.lookAt(Elyse.orientation.LEFT);
	}
	return this;
}