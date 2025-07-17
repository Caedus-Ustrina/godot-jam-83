extends Node

@export var Damage = 5
var Health = 100
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	Signals.connect("DamageAmount", Callable(self, "DamageDealt")) #listening for signal from globalscript that was called by the enemy
	print("connected to damage")

func DamageDealt():
	Health -= Damage
	print(Health)
	if Health <= 0:
		print("you dead") #end game


	
 
