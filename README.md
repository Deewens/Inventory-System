# 2D Inventory System for Unity

This Unity package add a simple (for now) and flexible inventory system to your game. The package will work seemingly
with your current game without you having to code anything.

## Current features

TODO

## How to use

### Set up the Inventory
You can give an Inventory to any entity of your game and the procedure is pretty simple.
1. Select the Entity **(GameObject or Prefab)** you want to add the **Inventory** to
2. Add the **Inventory Manager** script to your Entity  
<img src="https://i.imgur.com/luuzDVX.png" width="30%">
3. Check that your Entity has a **RigidBody2D** to enable the trigger and collect item

### Create an item
1. Right-click in the *Project* view and go to **Create** -> **Inventory System** -> **Item**.   
<img src="https://i.imgur.com/eTmm5Lc.png" width="40%">  
2. Enter the information for your new item in the Scriptable Object you just created  
<img src="https://i.imgur.com/S1I0gMM.png" width="40%">
   1. Enter a name and a description
   2. You should give an icon to your item for it to be displayed in the UI, the Icon should be a sprite
   3. The Prefab property will be explained next
3. Create a new Prefab in your Project and add it a **Sprite Renderer**
   1. Add the item **icon** to the Sprite Renderer if you want (the icon will be set by the script anyway)
   2. Add the script called **Item** to your Prefab  
   <img src="https://i.imgur.com/4ytb2aF.png" width="20%">
   3. Add the Scriptable Object to the **Item Data** property of the script  
   <img src="https://i.imgur.com/wWEb2Qz.png" width="30%">
4. Now, you can fill the **Prefab** property of the Scriptable Object your created before with the Prefab you just created

## Futures

TODO