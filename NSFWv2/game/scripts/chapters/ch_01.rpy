# Welcome to Chapter 1, ChElevator.
# Summary:
# This is the intro chapter where PC gets introduced
# to all of the cast of characters in the game.

label ch_01:

    scene black
    "You straighten your coat again for the 20th time today."
    y "{i}Oh boy{/i}"
    "You thought, gently pressing your hand where your heart is trying your best to keep it from bursting out of your chest."
    "To distract yourself from your nerves, you scan the room you're in."

    scene bg_ch01_elevator
    with dissolve
    "Currently, you're sitting in a metal box zooming you to the heavens..."
    "...more commonly known as the 46th floor."
    "The gentle whirring of the elevator hamonizes with the dramatic drum solo blasting in your chest as you approach your floor."
    y "{i}Is that-{/i}"
    y "{i}...{/i}"
    y "{i}...jazz?{/i}"
    y "{i}What am I here for again?{/i}"
    "You rack your brain for the last few moments that lead you here in the first place."
    
    scene bg_ch01_windows
    with pixellate
    "A few weeks ago, you saw an ad while applying for jobs online."
    "You clicked on it, desperate to find any Human Resource jobs you could apply to."

    scene bg_ch01_advertisement
    "What you didn't know was that by clicking on the ad, you had inexplicably signed an undisclosed-yet-legally-binding-contract for a human resource internship position with BizNiz Inc."
    "Unpaid, of course."
    "{i}Business things for all your business needs!{/i}"
    "They really couldn't be more shady if they tried."
    "Either way, you're legally bound."

    scene bg_ch01_elevator
    with pixellate
    "In an effort to not get sued, you're now headed to BizNiz Inc. HQ."
    "The time is 8:57 AM and you're now very much regretting spending an extra 20 minutes making sure your lunch sandwich had the perfect sauce-to-bread-to-meat-to-lettuce ratio."
    y "{i}Maybe I should think about managing my time better?{/i}"
    "You think, as you reminisce of your previous job which you had been fired from."
    "One which you had a record of 1 out of 25 days working there where you actually came on time."
    "And that was only because you thought the work hours started an hour early."
    "You were definitely swift to correct that {i}'mistake'{/i}."
    "Despite all that, you were still able to land another job pretty quickly after that fiasco."
    y "I hope I don't fuck it up again this time."
    u "{b}{i}Ahem{/i}{/b}"
    "When you came to from your thoughts, you remembered that you're not the only person on this elevator."
    show td_serious at truecenter
    with fade
    "You see that the man had been right beside you the entire time, eyeing you while you were doing..."
    "...whatever you were doing."
    "You get a little flushed from that realization."
    y "{i}Well that's embarrasing.{/i}"
    u "How are you holding up, son?"
    y "Yes, sir."
    u "Well that's one way to answer that question."
    u "But just to be {b}extra{/b} sure you're on planet earth right now..."
    $ yName = renpy.input("...what's your name?", default="Matt")
    $ yName = yName.strip()
    
    if yName != "Matt":
        u "{i}[yName]??{/i}"
        u "Are you sure?"
        u "Because I'm pretty sure you wrote \"Matt\" on your resume and job application."
        menu:
            "Nod your head":
                "You nod"
                "So is that a \"yes\" for \"Matt\" or for \"[yName]\"?"
                menu:
                    "Matt":
                        $ yName = "Matt"
                        jump ch_01_01_A
                    "[yName]":
                        u "Well, whatever you say..."
                        u "...[yName]"
                        "He says as you see him crossing out your name on your resume and job application forms and replacing them with \"[yName]\""
                    "Apple Sauce":
                        u "Ohhhh"
                        u "You skipped the most important meal did you, son?"
                        u "I know just the cure!"
                        "You see the man rustling in his pockets for something."
            "Shake your head":
                "You shake your head"
                u "Huh..."
                u "Well you do you, kid."
                "He pats your head"
                u "You can take your time figuring out who you are. It's nothing to rush."
                u "For now, I'll just call you [yName]."
                u "So, has [yName] had beakfast yet?"
        jump ch_01_01_B
    
    label ch_01_01_A:
        u "Huh, I thought as much."
        u "Stop messing with me so early in the morning"
        u "I haven't even had my coffee yet."
        u "Speaking of..."
        u "...you had breakfast yet, son?"
    label ch_01_01_B:
        show td_hand
        u "Here"

    "Before you could respond to his question, the man hands you a box of grape juice."
    "You sheepishly take the box of juice and immediately sip on it."
    show td_serious
    "You sipped in silence as you looked around the elevator again for something to do."

    menu:
        "Check reflection":
            "You look at your reflection."
            "Or at least whatever you could make out from the blob of colors reflected off of the elevator doors."
            "You somehow see a charming young man in a bespoke business attire."
            "Although now that you're looking at it, you might've bought a size too small for yourself."
            show td_embarassed
            u "I hope you aren't choking in that tie of yours. Really sorry about the dress code, by the way."
            u "We are operating a {i}\"business\"{/i} after all."
            show td_proud
            u "Really if it were up to me, you can wear something more like this."
            show td_batik
            "The man pulls on one side of his suit coller to reveal an elaborate pattern of flower motifs drawn on his shirt."
            "All of this ingeniously hidden underneath his suit with only the uncovered parts being fully white."
            u "Cool, right?"
            u "It's called Batik."
            u "Shame management prefers their employees more plain and grey."
            "He fixes his suit to hide the beautiful Batik design underneath."
            "As he is busy doing this, you noticed a name tag that says \"Manager\" but it is crossed out with \"Dad\" written above it instead."
            $ uName = "Dad?"
            u "I bought this one from Fam's & Friends. Remind me to bring you shopping there some-"
            "{b}DING!{/b}"
            "The elevator dings as you reach your floor, interrupting the man mid-sentence."


        "Wave at camera":
            hide td_serious
            "You raise your hand to wave at the elevator camera"
            "The camera did not wave back."
            "<SLAP SOUND EFFECT!!!>"
            "The manager gave you a high five before you could put your hand down in disappointment."
            u "Gahahahaha! I do love a good high five, don't you?"
            u "My daughter used to {b}love{/b} the {i}\"down low, too slow\"{/i} bit."
            u "Until she got faster than me, in which case, it just became a double-five."
            "{b}DING!{/b}"
            "The elevator dings as you reach your floor. The man steps out onto the office floor."
            u "Kids just grow up too fast these days, don't they?"
            u "Now come along, son. I've got a whole office to show you today."

    ## CONTINUE HERE
    
        "Twiddle thumbs":
            "You stare into space, trying not to overthink how you're not going to screw this up; and failing"
            y "{i}You got this fam. Believe in yourself just like how grandma believes in you. Remember that \"{b}BELIEVE IT{/b}\" sweater that she gave you for Christmas? The one with the cat in the hat? Yeah, that one. That cat believes in you wholeheartedly. {/i}"
            u "...son?"
            y "{i}Remember that cat. Remember grandma. She wouldn't want you to overstress yourself with anxiety. She'd want you to believe in yourself. And if you can't believe in yourself, you have to believe in the you{/i}"

    show ch_smug at truecenter
    ch "[yName], huh. Alright."
    show ch_down at truecenter
    "The lady flipped through the documents in her hand. You intantly recognzed it to be your CV and portfolio.."
    "Who was she anyway? A secretary?"
    "From the looks if her outfit it looks like she'd fit the part."
    "And the stern expression she has."
    "But her little bun makes her look like there's a cherry on her head, it's cute."
    show ch_cas at truecenter
    "Maybe she actually was the secretary around here."
    "You gave yourself a pat on the shoulder. You're just nervous. It's all gonna be okay."
    show ch_angr at truecenter
    ch "..Mr [yName]!"
    "Your head snapped to the secretary lady instantly. Well fuck, what an impression already."
    "The lady sighed, clearly annoyed that she has to put up with you already, as her hand is seen holding the elevator door."
    "Fuck."
    ch "Well? Are you going to come outside or what? I canot hold this elevator for too long. Please keep up."
    y "Sorry!"
    show ch_cas2 at truecenter
    "You exclaimed, hurrying out the elevator doors and into the office."
    "At the reception desk, you see a small girl with her hands all over her keyboard typing away."
    ch "Right, first things first."
    "You turned towards her."
    ch "I believe I have not introduced myself yet."
    show ch_cas at truecenter
    ch "My name is Cherry, Cherie Belanger. You can drop the formalities around here, you can I'm the secretary around here, anything happens or if you need anything you need to report to me."
    "Cherry spoke with her eyes glued to the clipboard, analyzing it still. Before you get the chance to reply, she continued."
    ch "That's Katya. She's our receptionist."
    show ch_down at truecenter
    "Her hand gestured towards the girl in white hair behind the desk. She only nodded a little with her eyes to the monitor."
    "Or was she? You couldn't really tell due to the bangs covering her eyes."
    "You nodded back with a small 'hi' and looked back at Cherry who was now away at the end of the hallway."
    "Upon walking there, you see... an entire wall... full of the same picture of the same guy..?"
    ch "To your right is the pantry for lunch breaks. You're free to sit anywhere on the couch and take whatever that's available as long as you clean up after yourself."
    show ch_cas at truecenter
    ch "Questions?"
    menu:
        "What's today's lunch and when can i get it?":
            y "What's on the menu today?"
            show ch_smug at truecenter
            ch "Don't know yet, but Mr. Rimau said he wanted spaghetti yesterday. So it's probably that."
            "What kind of office gives out spaghetti as lunch..? Isn't that expensive..?"
            "You wiped away the drool at the thought of getting spaghetti... mm... bolognaise..."
            y "When can I get it?"
            show ch_cas at truecenter
            ch "Your lunch break is at 2pm, Mr. [yName]. You have approximately four hours and fifty-four minutes before that."
            "Your knees dropped to the ground in defeat."
            "Cherry sighed and shook her head."
            "No spaghetti... for five hours..."
            "Teardrops stained the cold, marble floors, your fist tightened in agony, despair, and the rumbling of your stomach."
            "You have not eaten in a few days (your last meal was an hour ago). A crumb, even a morsel of the sweet tomato paste would be great right about now..."
            show ch_disg at truecenter
            "Cherry stared at you with an expression that's hard to describe other than the look of utter disappointment already and the realization that she'd just hired another weirdo."
            ch "Right, get up, Mr. [yName], I'm not done explaining to you yet."
            "You wailed internally for a second before promptly getting up and fixing your suit and tie back. You sniffed the sniffle away and wiped your tear, standing straight back up as Cherry shook her head again."
            y "What about that door?"

        "Wall of man?":
            "You pointed towards the wall of the probably hundreds of framed pictures of the same man in green hair."
            y "Who's he and why are there so many pictures of him?"
            "Cherry turned to said wall, sighed, and placed a hand on her hip."
            ch "This is supposed to be the Employee of the Month section,"
            "She motioned her hand to point toawrds the entirety of the wall."
            ch "But we just call it the 'Arlo Wall' at this point 'cus the same guy keeps getting them for like, three straight years now."
            ch "Oh, and that's who we call Arlo, Mr LeCoultre-Hearst. He has been awarded with the honour since his employment in Branch Division. He is the best of the best and someone whom you should strive to be."
            ch "We keep raising his KPIs but he blows them out of the water every time."
            "Cherry sighed."
            ch "Unfortunately you will not be seeing him as much. He has a rather... Interesting hobby that we can't really stop him from."
            ch "Not that I haven't tried, mind you."
            "She held her head as if she had a headache, along with a snarl."
            ch "But the Boss said I should just leave him be. Since he's doing great work and all. Honestly, I don'ot know {i}what{/i} he does but he manages to maintain it every single time, so whatever."
            "You were a bit confused at that. What sort of hobby does he have that makes him this smart and the division's best employee yet manage to annoy Ms. Cherry so much?"
            "Well, whatever he does, it sparked a bit of spark to strive to be like him."
            y "What's beyond the door?"

        "I'm ready to move on.":
            "You took a quick look around, taking note of the wall of green-haired man and the lounge and pantry area."
            "In the pantry area, you see some couches, a big table, a vending machine and the pantry area with food. The wall is decorated with small items like worn out posters on how to wash your hands, no littering, and a what seems to be a poster of a fish? Giving a thumbs up...?"
            "You blinked but turned back towards Cherry, who seems to be mumbling under her breath about something."
            y "I don't."

    label ch_01_02:
        show ch_down at truecenter
        "Cherry nodded, turned around and walked past the door. You followed suit."
        "To your left you see an open office. It had a monitors on some desks, a few files and papers stacked on each other."
        "In this mess it looked surprisingly neat."
        show ch_cas at truecenter
        "To the back of the office you see a cubicle. That cubicle was tall, but even taller were the amount of papers and files that were stacked inside that cubicle as it went as tall as the ceiling, and probably more on the floor."
        "The walls were decorated with whiteboards of notes and meeting discussions, another side had it filled with a corkboard showing various posters of different topics, written sticky notes, as well as cabinets of various colored labels."
        "And a water dispenser."
        show ch_cas2 at truecenter
        ch "That's your work station. If you have a laptop, feel free to connect to the monitors provided."
        ch "People will drop by to grab some papers and files, and do work here too. I do hope you get along with them, as they can be a bit... Special."
        "Cherry rolled her eyes at that thought. You gave her a nod."
        y "By special, do you mean that they-"
        ch "Questions later, Mr. [yName]. Here's our boss's office, though it seems like he's out at the moment."
        "She said as she gestured to the door behind her. The walls had windows as well as the door, but all of them seemed to have their curtains drawn."
        show ch_down at truecenter
        "Understandably so, the boss must be quite busy, managing a prestigious office like this."
        "{i}BRANCH MANAGER, MR RIMAU{/i}, the sign on the door wrote."
        "Must be an intimidating guy for a man with that sort of name."
        "Cherry started walking again to the room just beside it."
        ch "Here's the meeting room. Oh, you might want to bring your own table or chair whenever we have them."
        ch "Someone keeps breaking them and we have no idea who, so feel free to bring your own."
        "Huh?"
        "Cherry opened the door to the meeting room for you to see.. At least three different types of tables: an office table, a square picnic table and a round table, all combined into one to make one.. big table..."
        "You blinked."
        "At the back you see the whiteboard that said {i}The Meeting Room{/i} and the last agenda that they had. The last meeting seems to be about three days ago. As well as a door, that hanged a sign that says 'Archive'."
        "Miss Cherry was right though, the was no chairs other than the worn out bean bag at the corner of the room."
        "Though you're almost sure that the seat is taken already."
        show ch_cas at truecenter
        ch "We keep sending requests for new tables to the higher ups, only for them to either come back, have them indefinitely on pending or they just don't read them at all."
        y "Yeesh."
        ch "Tell me about it. Anyway."
        "Cherry closed the door."
        "Turning to the corner of the hallway you see three different labelled rooms."
        "The Broom Closet occupied the end of the hallway while the other two rooms were opposite of the meeting room and Mr Rimau's office. The two doors labelled I.T {s}Manager{/s} Guy, and Accountant."
        "In front of the accountant's room had stacks of cereal boxes with a bowl and spoon on top."
        "And by stacks, there's like two rows of the same cereal, but of consisted of two other different colored stripes. Probably of different flavors."
        "The room beside it however, the window.. looks like it's about to burst with water."
        "...If you look close enough, there are fishes swimming about...?"
        "Yeah it looks like that. But how does that even work? Is it a full on aquarium in there?"
        "But most importantly who's in there? The door says I.T Guy, but-"
        "Your thoughts were interrupted by Cherry clearing her throat."
        show ch_disg at truecenter
        "She had a displeased look on her face."
        ch "Are you done sightseeing?"
        "When you came to you realized that you had planted your face right onto the window of the fishes swimming about."
        show ch_cas2 at truecenter
        "You immediately retracted yourself from that position, cleared your throat and ajusted your tie back in position."
        "Cherry, for the hundredth time today, shook her head, sighed very loudly while muttering something under her breath again."
        "You gave her a goofy smile."
        ch "So, what would you like to do now?"
        show ch_cas at truecenter
        menu:
            "Ponder what happened today.":
                "You tapped a finger to your chin, as you're thinking..."
                "You recalled what happened today."
                jump ch_01
            "Think about something other than your job.":
                "You tapped a finger to your chin, as you are thinking..."
                "You wondered how life would be if you're not working here."
    return