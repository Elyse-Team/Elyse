Elyse.Character = function(stage, options){
	this.name = options.name;
	this.head = options.head || 'smile';
	this.body = options.body || 'blue';

	this.textures = {
		head : PIXI.Texture.fromImage('./assets/img/' + Elyse.Character.heads[options.head || 'smile'].path),
		body : PIXI.Texture.fromImage('./assets/img/' + Elyse.Character.bodies[options.body || 'blue'].path)
	};

	this.sprites = {
		head : new PIXI.Sprite(this.textures.head),
		body : new PIXI.Sprite(this.textures.body)
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

	this.displayObject.x = options.x || (320-this.displayObject.width)/2;
	this.displayObject.y = options.y || 450-this.displayObject.height;


	Object.defineProperty(this, "x", {
    	get: function() { return this.displayObject.x; },
    	set: function(value) { this.displayObject.x = value}
  	});

  	Object.defineProperty(this, "y", {
    	get: function() { return this.displayObject.y; },
    	set: function(value) { this.displayObject.y = value}
  	});

	stage.addChild(this.displayObject);
}

//Consts

Elyse.Character.heads = {
	smile : {
		path : 'smile.png',
		dx : 0,
		dy : 0,
		scale : 0.7
	}
}

Elyse.Character.bodies = {
	blue : {
		path : 'body-blue.png',
		dx : 0,
		dy : 0,
		scale : 0.7
	}
}

//Methods

Elyse.Character.prototype.update = function(callback){
	
}

Elyse.Character.prototype.move = function(){
	//Not implemented method
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