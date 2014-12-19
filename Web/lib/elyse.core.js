var DEBUG = true;

var Elyse = {};


Elyse.stage = new PIXI.Stage(0xFFFFFF);

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
Elyse.renderer = PIXI.autoDetectRenderer(1600, 900, null, true);
Elyse.rendererContainer = document.body;
Elyse.assets = new PIXI.AssetLoader();

if(DEBUG){
	var grid = new PIXI.Graphics();
	grid.lineStyle(1, 0xFF0000);
	grid.drawRect(0, 0, 960, 900);
	grid.drawRect(320, 0, 960, 900);
	grid.drawRect(640, 0, 960, 900);
	grid.drawRect(0, 0, 1600, 450);
	Elyse.stage.addChild(grid)
}


Elyse.orientation = {
	LEFT : 1,
	RIGHT : -1
};

Elyse.positions = {
	OUTLEFT : -400,
	OUTRIGHT : 2000
};



Elyse.actions = [];

Elyse.entities = {};
Elyse.entities.list = [];
Elyse.entities.add = function(options){
	var c = new Elyse.Character(Elyse.stage, options);
	Elyse.entities.list.push(c);
	return c;
};
Elyse.entities.update = function(){
	var i = Elyse.entities.list.length;
	while(i-->0){
		Elyse.entities.list[i].update();
	}
}



Elyse.run = function(){

};

Elyse.rendererContainer.appendChild(Elyse.renderer.view);


function animate(){
	Elyse.entities.update();
	requestAnimationFrame(animate);
	Elyse.renderer.render(Elyse.stage);
}



