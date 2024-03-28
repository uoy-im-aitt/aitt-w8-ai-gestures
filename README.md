# Week 8 Practical: AI Gesture Recognition with InteractML

In this week’s lecture, we learned about AI and how relevant it is to the development of advanced interaction experiences. We saw how machine learning can allow us to train computers to do complex tasks by showing them lots of examples of a desired action or output.

One of the use cases for this approach we saw in the lecture was gesture recognition. Think back to the motion practical in the third week of this course. We used a simple `if` statement to swing a sword when a mouse moved downwards. As you can imagine, this approach to gesture recognition is pretty limited: our code will get very complex for anything more than the most basic gestures. 

But what if, instead, we could teach a computer to detect a gesture by just showing it examples of that gesture? Today we’re going to learn how to do just this, by using a Unity plugin (created by a PhD student here at York) called InteractML.

## Task 1: The Spellcasting Game

The practical today will build on a simple spellcasting game. To get hold of this game and all of the other files you’ll need for today you should create a copy of this repository in your personal GitHub account by pressing the `Use This Template` button. Once you’ve done this you should `clone` it onto your local machine. Finally, open the `WizardGame` scene in the `Practical Assets` folder.

> [!WARNING]
> This repository includes the InteractML github repository as a submodule. If you clone the repository using GitHub desktop it'll automatically include this submodule for you. However, if you're using git on the comamnd line you'll need to use the following command `git clone --recurse-submodules <repository url>` (note the additional parameter, compared to a normal clone). 

Play the scene and try out the game. It is very simple. You can:

- Move your want around using the mouse, creating some particle trails
- Cast one of four different spells at the zombie, by pressing the numbers 1-4 on the keyboard

The keyboard based interaction works. But wouldn't it be cool if we could cast the different spells by performing gestures with the wand?

## Task 2: Exploring an InteractML Graph

In the practical today, we are going to learn to use InteractML (IML) in order to control the simple spellcasting game using gestures detected via machine learning. IML is a toolkit that was made to allow designers and artists to use machine learning more easily and without using much code. You can find more about it [here](https://interactml.com).

To help you get started, I’ve created a simple IML graph that can be used to ‘train’ and ‘detect’ basic gestures based on the position of a game object. In this task, we’re going to look at this graph to understand how it works. Click on the `IML System` game object in the hierarchy. Then, find the `IML Component` in the inspector and double click on the `SpellGestureGraph` asset in the `Graph` box. A new window should open that looks like this.

![imlgraph](https://github.com/uoy-im-aitt/aitt-w8-ai-gestures/assets/2250660/bd08a20b-e26e-4228-8789-2807a3eb5522)

Let's talk through some of the main bits of this graph and what they do:

- The `Game Object` box represents a particular game object in our scene that we want IML to learn something about. In this case, I’ve associated this box with an invisible game object at the tip of the wizard’s wand.
- The `Position` box extracts the position of this game object as three `x, y, z` coordinates. This is the actual data that we will use to train our machine learning model.
- The `Teach the Machine` box allows us to train a machine learning model based on a set of example position values extracted from the game object. Notice that there is a line connecting the position of our game object to an input called Live Data In.
- The leftmost `Integer` box allows us to simply specify a label that should be associated with a particular gesture you want the machine learning model to recognize. This is connected to the `Teach the Machine` box to tell it which gesture you’re currently showing it an example of.
- The `Keyboard Input` box let’s us send a message to another box when a key is pressed. You can choose which key using the drop down boxes. In this case, the box is setup so a space bar causes the `Teach the Machine` box to record one example and associate it with the label specified by the `Integer` box.
- The `Machine Learning System` box is the actual machine learning model that you train to do the gesture recognition. Once you’ve shown enough examples to the `Teach the Machine` box, you can press its `Train Model` button and it’ll try to learn what you’ve shown it. Then you can press it’s `Run` button and it’ll begin recognizing.
- The rightmost `Integer` box shows the label of the gesture that’s been recognized. For example, if the model has detected you’ve just done the gesture you labelled `1`, a `1` will appear here.
- Finally, the `Spellcaster(Script)` box represents a script in our scene that is sent the label of the gesture that’s been recognized. It’ll then cast the right spell.

Spend some time exploring the graph to see if you can understand what it does and how. If it doesn't make sense yet, don't worry. Things will be clearer once we start using the graph to train our game to recognize gestures.

## Task 3: A Simple Position-based Gesture Recognizer

Now we’ve seen what the main bits of the IML graph are, let’s use it to train our first gesture recognition machine learning model! 

Let’s start by training the model to associate the label `0` with the wand resting in a central position. Follow these steps to do this:

1) Check that the value in the leftmost `Integer` box is set to `0`
2) Run the game and click within the game view
3) Move the wand so that it is broadly in a central position
4) Press the spacebar (this will record an example)
5) Move the wand so its in a slightly different central position
6) Press the spacebar again
7) Repeat until you’ve recorded about 10 examples

Now let’s train the model to associate the label `1` with the wand pointing to the top-left corner of the screen. Follow these similar steps to do this:

1) Check that the value in the leftmost `Integer` box is set to `1`
2) Move the wand so that it is pointing up to the top left
3) Press the spacebar to record an example
4) Repeat for 10 or so examples of slightly different top-left-pointing positions

Now let’s train our model based on that data. To do this follow these steps:

1)	Click the `Train Model` button
2)	Press the `Run` button

Now return to the game. You should find that when you point the wand toward the top left the Red `1` spell is cast, whereas if you move the wand back to the middle nothing happens.

To complete the task, train the model so that:

- The Red `1` spell is cast in the top-left
- The Green `2` spell is cast in the top-right
- The Purple `3` spell is cast in the bottom-right
- The Yellow `4` spell is cast in the bottom-left
- No spell (i.e. label `0`) is cast when the wand is in the middle

## Task 4: Adapting the Recognizer to Detect Gestures based on Velocity

Now you’ve trained a model that I’ve built, let’s see if you can make one of your own. In this task, you should adapt the `SpellGestureGraph` so that instead of triggering spells based on the position of the wand, it triggers then when the wand moves with a certain velocity and in a certain direction. 

Here are some tips to help you do this:

- You can train an IML model based on the velocity of an object instead of its position by adding a `Velocity` box between the existing `Position` box and the `Teach the Machine` and `Machine Learning Model` boxes. You can create one of these by right clicking and choosing `InteractML > Game Object Movement Features > Velocity`.
- You’ll need to reset your training examples and model so it doesn’t get confused by the position examples you’ve already shown it. Press the `Delete All Recordings` and `Reset Model` buttons to do this.

What interaction feels more satisfying: position-based or velocity-based gestures?

## Task 5: More Complex Gesture Recognition using Dynamic Time Warping

Wouldn’t it be cool if we could train our model to learn even more complex gestures? For example, what if we could cast one spell by making a circle with the wand tip, and another by moving it up and down three times? This isn’t possible with the basic classification model we’re currently using in our IML graph, because it only considers single values (e.g. one labelled position value per example). What we need instead is a machine learning model that can be trained on a series of positions representing a more complex gesture.

In IML it is possible to use an alternative machine learning approach called `Dynamic Time Warping` (DTW) to train a model that recognizes time series data (e.g. lots of positions one after the other). You can find out more about what DTW is and how it works [here]( https://www.theaidream.com/post/dynamic-time-warping-dtw-algorithm-in-time-series#:~:text=In%20time%20series%20analysis%2C%20Dynamic,similar%20elements%20between%20time%20series).

In this task, you should adapt the `SpellGestureGraph` to use a `Dynamic Time Warping` approach instead. To start off with let’s replace the classification model that we’ve got in our graph with DTW. Follow these steps to do this:
 
1)	Remove the `Velocity` box you created in the last task. You can train a DTW model based on velocity, but let’s start with position to keep things simple.
2)	Delete the current `Teach the Machine` and `Machine Learning System` boxes, and replace them with new boxes that enable you to train and run a DTW model. You can create these by right clicking and choosing `Interact ML > Teach the Machine > TTM DTW` and `Interact ML > Machine Learning System > MLS DTW`.
3)	Connect up these boxes in the same way they were connected in the prior graph. If you can’t remember what should connect to what, the picture in task 1 should help.

There are a couple of differences we need to consider when training a model using time series data and DTW.

-  When we record an example gesture, we need to record many position values over time instead of just one. We can adapt our graph to do this by changing the drop-down menu in the `Keyboard Input` box from `Down` to `Hold`. If we do this, then our new DTW `Teach the Machine` box will record an example gesture for the whole time we hold down the space bar.
- We also need to tell the DTW `Machine Learning System` when we are performing a gesture that we want it to try and detect. A simple way to do this is to only have the machine learning system try and detect a gesture when the mouse is held down. To make your graph work this way, make a connection between the `mouseHeld` output of the `SpellCaster(Script)` box and the green dot next to the `Populate` button on your DTW `Machine Learning System` box.

If this works, you should be able to record examples of complex gestures by holding down the space bar while you perform them. Then, once you’ve trained your model, cast spells by performing those gestures while holding down the mouse!

See if you can make a different gesture for every spell (e.g. a circle, a triangle, a swipe etc.). Does the system get confused between certain gestures? Does showing more examples help?

## Optional Extension: Gestures in VR

We've learned how to train some basic gestures in InteractML based on mouse movement in this class. However, where InteractML comes into its own is with VR. As an extra task, why not try creating a VR experience where the movements of the HTC Vive controllers are used for gesture recognition? The latest VRInterface branch of InteractML (only works on Windows) even has support for viewing IML Graphs and training models from within VR. You can get this branch on the [InteractML GitHub repository](https://github.com/Interactml/iml-unity/tree/VRInterface).




