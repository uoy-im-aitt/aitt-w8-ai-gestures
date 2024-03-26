# Week 8 Practical: AI Gesture Recognition with InteractML in Unity

In this week’s lecture we learned about AI and how relevant it is to the development of advanced interaction experiences. We saw how machine learning can allow us to train computers to complex tasks by showing them lots of examples of a desired action of output.

One of the use cases for this approach we saw in the lecture was gesture recognition. Think back to the motion practical in the third week of this course. We used a simple `if` statement to swing a sword when a mouse moved downwards. As you can imagine, this approach to gesture recognition is pretty limited -- our code will get very complex for anything more than the most basic gestures. 

But what if, instead, we could teach a computer to detect a gesture by performing examples of that gesture? Machine learning lets us do this. Today we’re going to learn how using a Unity plugin created here at York called InteractML.

## Task 1: A Simple Spellcasting Game

The practical today will build on a simple spellcasting game. To get hold of this game and all of the other files you’ll need for today you should create a copy of this repository in your personal GitHub account by pressing the `Use This Template` button. Once you’ve done this you should `clone` it onto your local machine. Finally, open the `WizardGame` scene in the `Practical Assets` folder.

The game is very simple. You can:

- Move your want around using the mouse, creating some particle trails
- Cast one of four different spells at the zombie, by pressing the numbers 1-4 on the keyboard

The keyboard based interaction works. But wouldn't it be cool if we could cast the different spells by performing gestures with the wand?
