var Jackie = Elyse.entities.add({
				name : 'Jackie',
				orientation : Elyse.orientation.LEFT
			});
var David = Elyse.entities.add({
				name : 'David',
				head : 'smile',
				body : 'blue',
				orientation : Elyse.orientation.LEFT,
				x : 1550

			});



Elyse.actions = [
	{
		actor : Jackie,
		method : 'move',
		args : [900,0]
	}
]