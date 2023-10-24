# Welcome to Not Safe For Work! A Totally SFW Dating Sim

# Variables =================================
define re = Character("Reagan")

define ch = Character("Cherry")

define y = Character("yName", dynamic=True)
define yName = "Matt"

define dissolve = Dissolve(0.5)
define pixellate = Pixellate(0.5, 5)

# Chapter Selection =========================
label start:

    jump ch_01
    return