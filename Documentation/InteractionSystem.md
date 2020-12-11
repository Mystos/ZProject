# Interaction system



## How does it work

The system is a prefab called **InteractionSystem**. It is currently attached to the player.
It features a **Collider** (could be any type of collider) set to *IsTrigger*.
The **InteractionSystem script** then register every *OnEnterTrigger* & *OnExitTrigger* event registered.
In order to limit the detected collision, the **InteractionSystem** prefab's layer AND interactable objects are set to "Interactable".

Each tick, the system look upon every registered collider and select the closest one. It show the interaction interface depending on this object and enables the player to interact with it.

If the player press the interaction button (currently set to E), the interact with the closest object happens.



## How to implement interactable objects

After creating your object (preferably as a prefab), you need to inherit from the **Interactable** script and implement the 3 methods :

- *Interact* : the actual interaction with the object
- *ShowInteractionInterface* : To show the linked interface : it could be anything that give feedbacks to the player.
- *HideInteractionInterface* : To hide previous feedbacks.

And in order to have interaction working, you need to set the layer to interactable.

Sometimes, you would need the object to have other layers and/or to collide with other objects. A simple workaround is to create an empty gameObject as a child, and put the interaction script, collider and layer on it.



## Example

Inside the project, the **SphereLight** prefab is a great example of an interactable object.




## 