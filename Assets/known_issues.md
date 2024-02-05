# Known Issues

## JU TPS Weapon Aim Rotation Error

### Description
When using a JU TPS weapon with the sample FPS scene, an error occurs
when the weapon clips into an object because it expects at least six
weapon aim rotations.

### Workaround
From Julhieco (JU TPS author):
> One way is to [add more reference positions](https://julhiecio.gitbook.io/ju-tps-documentation/game-development/how-to-use-inventory-and-add-items/how-to-align-weapon-rotation) in the Item Aim Rotation Center
> 
> Copying the Item Aim Rotation Center from the third-person controller prefab
> 
> Removing the PreventGunClipping.cs script from the weapons

The currently used workaround in the FPS Sample scene is that two extra weapon
aim rotations were added called 'Padding' which use the `Big Weapon Position Reference`
game object as the reference.