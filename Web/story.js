var scene = {
		container : document.getElementById('scene'),
		debug : true
	},
	story = new Elyse(scene);


story.setBackground('beach');

var Jackie = story.addCharacter({
				name : 'Jackie',
				orientation : Elyse.orientation.LEFT
			});
var David = story.addCharacter({
				name : 'David',
				head : 'smile',
				body : 'blue',
				orientation : Elyse.orientation.LEFT,
				x : 1550
			});



story.actions = [
	[Jackie, 'move', [900,0]],
	[David, 'move', [900,0]]
]



story.run();