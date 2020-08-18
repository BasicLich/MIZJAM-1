using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StringSplitter : MonoBehaviour
{

    private string input = "Braindead juggler,Babyrage,Homunculus,Banned,Ms DeLeon,Retrograde Ejaculation,Weird Al,Gulag,Wallace Loh,Hitler Youth,NEET,Casanova,Lolita,Master Roshi,Kazakhstan,McKeldin Masturbator,Ofay,Edward James Olmos,Waterboarding, Schwarz, Chuck Berry,Eric Cartman,Bird Law,Wahhabism,Jewish Shadow Government,Mosque,Toast,Gambling,Leukemia,Syzygy,Othello,Last Week’s Baron,Shit Prophet,Gopnik,Vodka,Prostate,Womb,Gang Rape,Pink Sock,Coup de Grace,Bingo Free Space,Rocket Surgery,Megan Fox,Ai Kurosawa,Lightning Car,Hitomi Tanaka,Red Velvet,Madoka Magica,Nisekoi, George R R Martin,Lucy Chen,Asian Thighs,Forced docking, braindead jungler,nocturne mid,five hundred year-old vampire loli,sexy monster girl,autoerotic asphyxiation,beanstalk,tons of damage,Riot Game,antiestablishmentarianism,George Miller,Midget,Wheaties, Goldfinger,Wakanda,Socialism,Fan Death,Hydrogen Bomb,Spirit Cooking,JIDF,,Augusto Pinochet,Simon Bolivar,Commies,Hokkaido,Anal Leaking,nigger,Mark Cuban,Eric DaSilva,Kool and the Gang,Pomf,Green Day,Pineapple,Yellow Fever,Scarlett Fever,Ebola,furry,Acoustic Guitar,Wolfgang Amadeus Mozart,Dr Mantis Toboggan,the implication,Thirsty,giant enemy crab,machine learning,dragon loli,fakku,Starvin Marvin,Ethiopia,cultural enrichment,diversity is our strength,white privilege,alternative facts,lock her up,shekels,jailbait,Ben Nelson,po po,I’m in,thanos,bean restaurant,what the fuck,good afternoon my octoroon,quadroon,vanilla,ice cream,slip and slide,Praise the sun, Bazinga,big bang theory,bad tv show,good tv show,king arthur,knights of the round table,lancelot,merlin,runescape,camelot,edgeville,captain planet,the flash,batman,superman,wonder woman,aquaman,spongebob squarepants,ptsd,C#,piano,The Hobbit,1984,Great Gatsby,Invisible Man,Beowolf,Batman Begins,Christian Bale,tom cruise,special,shrimp boat,run forest run,pulp fiction,say what again,rocky,sylvester stallone,karate kid,back to the future,seven,wow,faggot,headshot,fat kid,chocolate bar,anorexia,bulimia,goku,vegeta,mayocide,gohan,piccolo,krillin,naruto uzumaki,believe it,cat doing backflip,falling,very sad man,very happy man,smile,nose hair,nose,big nose,small nose,rude nose,sad nose,bad nose,rad nose,surfing nose,Chinese cartoons,Sheldor,I put on my robe and wizard hat,buying gf,party hat,Lumbridge,Pallet Town,Cinnabar Island,Mt.Moon,Safari Zone,Youngster Joey,shorts,He-Man,Skeletor,HTML,Blockchain,To Kill a Mockingbird,Animal Farm,Catcher in the Rye,The Stranger,Moby Dick,American Psycho,Fight Club,GigaNigga,Surprise Motherfucka,MLG,VapeNation,Oh Baby a Triple,tactical nuke,God Hates Fags,Westboro Baptist Church,Giga Swastika, Courage the Cowardly Dog,Longcat,Keyboard Cat,Bongo Cat,Kermit,Bobobo,hover hand,Make America Great Again,Supply Side Economics, Shoah, Doge,Ricardo Milos,weed gang,bigger nigger, Dan Schneider, ICarly,Ariana Grande,LAMP,Eating ass,All Lives Matter,Despacito,,Black Lives Matter,Terry Crews,drake,drake and josh,Aladdin,Kendrick Lamar,Send Nudes,big tiddy goth gf,washboard,flat-chested,faggot pyramid,where da hood at,Overwatch porn,World Of Warcraft,pot of greed,skribbl.io, Cory in the House, Magnetic Wand Tool, Flat is Justice, bean, bean, Winnie the Pooh, blue lives matter,Wicca, Ram Ranch, ultraviolence, horrorshow, lorry, John Wayne, Nick Cage, Mel Brooks, Bruce Lee, Car Hole, Propane, George Patton, Psalms, Lovecraft, Nation of Islam, Alex Jones, Panchen Lama, Xenophobia, Xenu, Robert Byrd, Bernie Sanders, Pancho Villa, Emiliano Zapata, Omegalul, Ice Poseidon, Kriss Kross, Geto Boys, Elvis Presley, Ja Rule, Pixelated Genitals, Onanism, Propaganda, Russiagate, Gamergate, Emailgate, King James Bible, Door, Beans, Python, hangover, Rasputin, beer, wine, vodka, dick cheney, golden gate bridge, suicide, disneyland, mickey mouse, spare tire, chronic back pain, blanket, Deus ex machina, New York City, Light Pollution, Coffee, Kafir, Abortion, Anchor Baby, Dog Spa, The Crusades, Colonizers, Ayaya, Old Glory, Jack Kevorkian, Phonies, Dr Dolittle, Adam Sandler, Jimmy Neutron, The Man With No Name,White People Shit, Benedict Arnold, Metallica, Prodigal Son, Clifford the big red dog, Godzilla attack, Jumping over a chair, Giant angry crab, Hand turkey, door door, door door door, skyscraper door, evil door, angel door, Blizzard, Will Smith, Jaden Smith, Mexican door, German door, Japanese door, Broke door, Men in Black,  Leprechaun door, legendary nose, nose door, bean door, empty box, suck, Super Luigi , Nintendo Entertainment system, Superman, Das Boot, Mongolian Navy, illicit, Furry, holy door, birthday party,  Sexual reassignment, Gay , free hong kong, NEET,China Numbah one, tiananmen square, Lightning Mcqueen, Vietcong, Potion seller,  Oddjob, Joker,illumanti,Ancient Rome,tigger,Freddie Figgers, disgusting black creatures, I can’t breathe, you ain’t black, Jeffrey Epstein, I got lasers, yessir, coronavirus, kung flu,  free hong kong, Kanye 2020, Joe Biden, best girl, buying ox, buying ax, bbqing gf, crying gf, peeing gf, paying gf, taxing gf, oiling gf, laying gf,  giga brain, Clifford the big red dog, Godzilla attack, Chair jumping, Giant angry crab, Hand turkey, door door, door door door, evil door, angel door, Mexican door, German door, Japanese door, Broke door, Leprechaun door, legendary nose, nose door, bean door,nose nose,nose nose nose, Bigdickbitch.com,Binders full of women, Infinity War, Kappa ";


    private void Awake() {
        CleanUpString();
    }


    public void CleanUpString() {


        string[] s = input.Split(',');

        string output = "";
        List<string> unique = new List<string>();
        for (int i = 0; i < s.Length; i++) {

            s[i] = s[i].Trim();
            unique.Add(s[i]);

        }

        unique = unique.Distinct().ToList();




        for (int i = 0; i < unique.Count; i++) {


            output += (" " + unique[i] + ",");
        }


        
        // Filename  
        string fileName = "CSharpCornerAuthors.txt";
        // Fullpath. You can direct hardcode it if you like.  
        string fullPath = Application.dataPath + "/" + fileName;
        // An array of strings  

        // Write array of strings to a file using WriteAllLines.  
        // If the file does not exists, it will create a new file.  
        // This method automatically opens the file, writes to it, and closes file  
        File.WriteAllText(fullPath, output);

    }



    }
