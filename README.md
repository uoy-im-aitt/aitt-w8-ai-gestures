# Week 8 Practical: AI Gesture Recognition with InteractML in Unity

In this week’s lecture we learned about AI and how relevant it is to the development of advanced interaction experiences. We saw how machine learning can allow us to train computers to complex tasks by showing them lots of examples of a desired action of output.

One of the use cases for this approach we saw in the lecture was gesture recognition. Think back to the motion practical in the third week of this course. We used a simple `if` statement to swing a sword when a mouse moved downwards. As you can imagine, this approach to gesture recognition is pretty limited -- our code will get very complex for anything more than the most basic gestures. 

But what if, instead, we could teach a computer to detect a gesture by performing examples of that gesture? Machine learning lets us do this. Today we’re going to learn how using a Unity plugin created here at York called InteractML.

## Task 1: The Spellcasting Game

The practical today will build on a simple spellcasting game. To get hold of this game and all of the other files you’ll need for today you should create a copy of this repository in your personal GitHub account by pressing the `Use This Template` button. Once you’ve done this you should `clone` it onto your local machine. Finally, open the `WizardGame` scene in the `Practical Assets` folder.

Play the scene and try out the game. It is very simple. You can:

- Move your want around using the mouse, creating some particle trails
- Cast one of four different spells at the zombie, by pressing the numbers 1-4 on the keyboard

The keyboard based interaction works. But wouldn't it be cool if we could cast the different spells by performing gestures with the wand?

## Task 2: Exploring an InteractML Graph

In the practical today, we are going to learn to use InteractML (IML) in order to control the simple spellcasting game using gestures detected via machine learning. IML is toolkit that is designed to allow designers and artists to use machine learning more easily and without using much code. You can find more about it [here](https://interactml.com).

To help you get started, I’ve created a simple IML graph that can be used to ‘train’ and ‘detect’ simple gestures based on the position of a game object. In this task, we’re going to look at this graph to understand how it works. To get started, click on the `IML System` game object in the hierarchy. Then, find the `IML Component` in the inspector and double click on the `SpellGestureGraph` asset in the `Graph` box. A new window should open that looks like this.

![imlgraph](https://github.com/uoy-im-aitt/aitt-w8-ai-gestures/assets/2250660/bd08a20b-e26e-4228-8789-2807a3eb5522)

Let's talk through some of the main bits of this graph and what they do:

- The `Game Object` box represents a particular game object in our scene that we want IML to learn something about. In this case, I’ve associated this box with an invisible game object at the tip of the wizard’s wand.
- The `Position` box extracts the position of this game object as three `x, y, z` coordinates. This is the actual data that we will use to train our machine learning model.
- The `Teach the Machine` box allows us to train a machine learning model based on a set of example position values extracted from the game object. You see that there is a line connecting the position of our game object to an input called Live Data In.
- The leftmost `Integer` box allows us to simply specify a label that should be associated with a particular gesture you want the machine learning model to recognize. This is connected to the `Teach the Machine` box to tell it which gesture you’re currently showing it an example of.
- The `Keyboard Input` box let’s us send a message to another box when a key is pressed. You can choose which key using the drop down boxes. In this case, the box is setup so a space bar causes the `Teach the Machine` box to record one example and associate it with label specified by the `Integer` box.
- The `Machine Learning System` box is the actual machine learning model that you train to do the gesture recognition. Once you’ve shown enough examples to the `Teach the Machine` box, you can press it’s `Train Model` and it’ll try to learn what you’ve shown it. Then you can press it’s `Run` button and it’ll begin recognizing.
- The rightmost `Integer` box shows the label of the gesture that’s been recognized. For example, if the model has detected you’ve just done the gesture you called 1, a 1 will appear here.
- Finally, the `Spellcaster(Script)` box represents a script in our scene that is send the label of the gesture that’s been recognized. It’ll then cast the right spell.

Spend some time exploring the graph to see if you can understand what it does and how. If it doens't make sense yet, don't worry. Things will be clearer once we start using the graph to train our game to recognize gestures.

## Task 3: A Simple Position-based Gesture Recognizer

Now we’ve seen what the main bits of the IML graph are, let’s use it to train our first gesture recognition machine learning model! 

Let’s start by training the model to associate the label `0` with the wand resting in a central position. Follow these steps to do this:

1) Check that the value in the leftmost `Integer` box is set to `0`
2) Run the game and click within the game view
3) Move the wand so that it is broadly in a central position
4) Press the spacebar button (this will record an example)
5) Move the wand so its in a slightly different central position
6) Press the spacebar again
7) Repeat until you’ve recorded about 10 examples of this

Now let’s train the to associate the label `1` with the wand pointing to the top-left corner of the screen. Follow these similar steps to do this:

1) Check that the value in the leftmost `Integer` box is set to `1`
2) Move the wand so that it is pointing up to the top left
3) Press the spacebar to record an example
4) Repeat for 10 or so examples of top-left-pointing positions

Now let’s train our model based on that data. To do this follow these steps:

1)	Click the train `Train Model` button
2)	Press the `Run` button

Now return to the game. You should find that when you point the wand toward the top left the Red `1` spell is case, whereas if you move the wand back to the middle nothing happens.

To complete the task, train the model so that:

- The Red `1` spell is cast in the top-left
- The Green `2` spell is cast in the top-right
- The Purple `3` spell is cast in the bottom-right
- The Yellow `4` spell is cast in the bottom-left
- No spell (i.e. label `0`) is cast when the wand is in the middle

## Task 4: Adapting the Recognizer to Detect Gestures based on Velocity

## Task 5: More Complex Gesture Recognition using Dynamic Time Warping


## Optional Extension: Gestures in VR

We've learned how to train some basic gestures in InteractML based on mouse movement in this class. However, where InteractML comes into its own is with VR. As an extra task, why not try creating a VR experience where the movements of the HTC Vive controllers are used for gesture recognition? The latest VRInterface branch of InteractML (only works on Windows) has support for viewing IML Graphs and training models from within VR. You can get this branch on the [InteractML GitHub repository](https://github.com/Interactml/iml-unity/tree/VRInterface).




