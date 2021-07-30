using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();
            context.Database.Migrate();
            var categories = new List<Category>()
                        {
                            new Category {Name = "Action" },
                            new Category {Name = "Advanture"},
                            new Category {Name = "Comedy" },
                            new Category {Name = "Crime" },
                            new Category {Name = "Drama"},
                            new Category {Name = "Mystery" },
                            new Category {Name = "Romance", Movies=
                                new List<Movie>(){
                                    new Movie
                                    {
                                        MovieTitle = "Eternal Sunshine of the Spotless Mind",
                                        MovieDescription = "When their relationship turns sour, a couple undergoes a medical procedure to have each other erased from their memories.",
                                        MovieImage = "EternalSunshine.jpg",
                                        MovieAbout = "IMDB rating is 8.3. It won 1 Oscar.Eternal Sunshine of the Spotless Mind (also simply known as Eternal Sunshine) is a 2004 American drama film written by Charlie Kaufman and directed by Michel Gondry. It follows an estranged couple who have erased each other from their memories. Pierre Bismuth created the story with Kaufman and Gondry. The ensemble cast includes Jim Carrey, Kate Winslet, Kirsten Dunst, Mark Ruffalo, Elijah Wood, and Tom Wilkinson. The title of the film is a quotation from the 1717 poem Eloisa to Abelard by Alexander Pope. The film uses elements of psychological thriller, science fiction and a nonlinear narrative to explore the nature of memory and romantic love. It opened in North America on March 19, 2004, receiving high acclaim from critics and audiences and grossed over $74 million worldwide. It won the Academy Award for Best Original Screenplay, and Winslet received a nomination for the Academy Award for Best Actress. The film developed a cult following in the years after its release and has come to be regarded by many critics as one of the best films of the early 21st century.",
                                    },
                                }
                            },
                            new Category {Name = "Sci-Fi" },
                            new Category {Name = "Thriller"}
                        };
            var votes = new List<Vote>()
                        {
                            new Vote()
                            {
                                Voting=1
                            },
                            new Vote()
                            {
                                Voting=2
                            },
                            new Vote()
                            {
                                Voting=3
                            },
                            new Vote()
                            {
                                Voting=4
                            },
                            new Vote()
                            {
                                Voting=5
                            }
                        };
            var movies = new List<Movie>()
                        {
                            new Movie
                            { //Drama
                                MovieTitle = "The Shawshank Redemption",
                                MovieDescription = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                                MovieImage = "Esaretin-bedeli.jpg",
                                MovieAbout = "IMDB rating is 9.3. It nominated for 7 Oscars. The Shawshank Redemption is a 1994 American drama film written and directed by Frank Darabont, based on the 1982 Stephen King novella Rita Hayworth and Shawshank Redemption. It tells the story of banker Andy Dufresne (Tim Robbins), who is sentenced to life in Shawshank State Penitentiary for the murders of his wife and her lover, despite his claims of innocence. Over the following two decades, he befriends a fellow prisoner, contraband smuggler Ellis Red Redding (Morgan Freeman), and becomes instrumental in a money-laundering operation led by the prison warden Samuel Norton (Bob Gunton). William Sadler, Clancy Brown, Gil Bellows, and James Whitmore appear in supporting roles. Darabont purchased the film rights to King's story in 1987, but development did not begin until five years later, when he wrote the script over an eight-week period. Two weeks after submitting his script to Castle Rock Entertainment, Darabont secured a $25 million budget to produce The Shawshank Redemption, which started pre-production in January 1993. While the film is set in Maine, principal photography took place from June to August 1993 almost entirely in Mansfield, Ohio, with the Ohio State Reformatory serving as the eponymous penitentiary. The project attracted many stars of the time for the role of Andy, including Tom Hanks, Tom Cruise, and Kevin Costner. Thomas Newman provided the film's score.",
                                Categories=new List<Category>(){categories[4] },
                                Votes=new List<Vote>(){votes[4],votes[3]},
                            },
                            new Movie
                            { //Crime/Drama
                                MovieTitle = "The Godfather",
                                MovieDescription = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                                MovieImage = "TheGodFather.jpg",
                                MovieAbout = "IMDB rating is 9.2. It won 3 Oscars. The Godfather is a 1972 American crime film directed by Francis Ford Coppola, who co-wrote the screenplay with Mario Puzo, based on Puzo's best-selling 1969 novel of the same name. The film stars Marlon Brando, Al Pacino, James Caan, Richard Castellano, Robert Duvall, Sterling Hayden, John Marley, Richard Conte, and Diane Keaton. It is the first installment in The Godfather trilogy. The story, spanning from 1945 to 1955, chronicles the Corleone family under patriarch Vito Corleone (Brando), focusing on the transformation of his youngest son, Michael Corleone (Pacino), from reluctant family outsider to ruthless mafia boss.</p> <p>Paramount Pictures obtained the rights to the novel for the price of $80,000, before it gained popularity. Studio executives had trouble finding a director; the first few candidates turned down the position before Coppola signed on to direct the film but disagreement followed over casting several characters, in particular, Vito and Michael. Filming took place primarily on location around New York City and in Sicily, and was completed ahead of schedule. The musical score was composed principally by Nino Rota, with additional pieces by Carmine Coppola.",
                                Categories=new List<Category>(){categories[4],categories[3] },
                                Votes=new List<Vote>(){votes[2],votes[4]},
                            },
                            new Movie
                            { //Drama/Romance
                                MovieTitle = "Forrest Gump",
                                MovieDescription = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                                MovieImage = "Forrest_Gump.jpg",
                                MovieAbout = "IMDB rating is 8.8. It won 6 Oscars.Forrest Gump is a 1994 American drama film directed by Robert Zemeckis and written by Eric Roth with comedic aspects. It is based on the 1986 novel of the same name by Winston Groom and stars Tom Hanks, Robin Wright, Gary Sinise, Mykelti Williamson and Sally Field. The story depicts several decades in the life of Forrest Gump (Hanks), a slow-witted but kind-hearted man from Alabama who witnesses and unwittingly influences several defining historical events in the 20th century United States. The film differs substantially from the novel. Principal photography took place between August and December 1993, mainly in Georgia, North Carolina and South Carolina. Extensive visual effects were used to incorporate Hanks into archived footage and to develop other scenes. The soundtrack features songs reflecting the different periods seen in the film.",
                                Categories=new List<Category>(){categories[4], categories[6]},
                                Votes=new List<Vote>(){votes[4],votes[1]},
                            },
                            new Movie
                            { //Crime/Drama/Thriller
                                MovieTitle = "The Silence of the Lambs",
                                MovieDescription = "A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.",
                                MovieImage = "silence_of_lambs.jpg",
                                MovieAbout = "IMDB rating is 8.6. It won 5 Oscars. The Silence of the Lambs is a 1991 American psychological horror film directed by Jonathan Demme and written by Ted Tally, adapted from Thomas Harris' 1988 novel. It stars Jodie Foster as Clarice Starling, a young FBI trainee who is hunting a serial killer, Buffalo Bill (Ted Levine), who skins his female victims. To catch him, she seeks the advice of the imprisoned Dr. Hannibal Lecter (Anthony Hopkins), a brilliant psychiatrist and cannibalistic serial killer. The film also features performances from Scott Glenn, Anthony Heald and Kasi Lemmons. The Silence of the Lambs was released on February 14, 1991 and grossed $272.7 million worldwide on a $19 million budget, becoming the fifth-highest-grossing film of 1991 worldwide. It premiered at the 41st Berlin International Film Festival, where it competed for the Golden Bear, while Demme received the Silver Bear for Best Director. It became the third film (the other two being 1934's It Happened One Night and 1975's One Flew Over the Cuckoo's Nest) to win Academy Awards in all the top five categories: Best Picture, Best Director, Best Actor, Best Actress, and Best Adapted Screenplay. It is also the only Best Picture winner widely considered a horror film, and one of only six horror films to have been nominated in the category with The Exorcist (1973), Jaws (1975), The Sixth Sense (1999), Black Swan (2010), and Get Out (2017)",
                                Categories=new List<Category>(){categories[4],categories[3],categories[8]},
                                Votes=new List<Vote>(){votes[3],votes[4],votes[0]},
                            },
                            new Movie
                            { //Drama/Horror/Sci-Fi
                                MovieTitle = "A Quiet Place",
                                MovieDescription = "In a post-apocalyptic world, a family is forced to live in silence while hiding from monsters with ultra-sensitive hearing.",
                                MovieImage = "A_Quiet_Place.png",
                                MovieAbout = "IMDB rating is 7.5. It nominated for 1 Oscars. A Quiet Place is a 2018 American horror film directed by John Krasinski and written by Bryan Woods, Scott Beck and Krasinski from a story conceived by Woods and Beck. The plot revolves around a father (Krasinski) and a mother (Emily Blunt) who struggle to survive and raise their children (Millicent Simmonds and Noah Jupe) in a post-apocalyptic world inhabited by blind monsters with an acute sense of hearing.</p> <p>Beck and Woods began developing the story while in college. In July 2016, Krasinski read their spec script and was hired to direct and rewrite the script in March the following year. The film drew inspiration from Alien, No Country for Old Men, and In the Bedroom. Krasinski and Blunt were cast in the lead roles in May 2017. Filming took place in upstate New York from May to November 2017.",
                                Categories=new List<Category>(){categories[4] ,new Category() { Name = "Horror" },categories[7] },
                                Votes=new List<Vote>(){votes[0],votes[2]},
                            },
                            new Movie
                            { //Action/Drama/Crime
                                MovieTitle = "Léon",
                                MovieDescription = "Mathilda, a 12-year-old girl, is reluctantly taken in by Léon, a professional assassin, after her family is murdered. An unusual relationship forms as she becomes his protégée and learns the assassin's trade.",
                                MovieImage = "Leon.jpeg",
                                MovieAbout = "IMDB rating is 8.5. It did not won Oscars. Léon: The Professional (French: Léon), titled Leon in the UK and Australia (and originally titled The Professional in the US), is a 1994 English-language French action-thriller film written and directed by Luc Besson. It stars Jean Reno, Gary Oldman, and Natalie Portman (in her film debut). The plot follows Léon (Reno), a professional hitman, who reluctantly takes in 12-year-old Mathilda (Portman) after her family is murdered by corrupt Drug Enforcement Administration agent Norman Stansfield (Oldman). Léon and Mathilda form an unusual relationship, as she becomes his protégée and learns the hitman's trade.",
                                Categories=new List<Category>(){categories[4],categories[0],categories[3] },
                                Votes=new List<Vote>(){votes[4]},
                            },
                            new Movie
                            { //Advanture/Biography/Drama
                                MovieTitle = "Into the Wild",
                                MovieDescription = "After graduating from Emory University, top student and athlete Christopher McCandless abandons his possessions, gives his entire $24,000 savings account to charity and hitchhikes to Alaska to live in the wilderness. Along the way, Christopher encounters a series of characters that shape his life.",
                                MovieImage = "Into.jpg",
                                MovieAbout = "IMDB rating is 8.1. It nominated for 2 Oscars. Into the Wild is a 2007 American biographical adventure drama film written, co-produced, and directed by Sean Penn. It is an adaptation of the 1996 non-fiction book of the same name written by Jon Krakauer and tells the story of Christopher McCandless (Alexander Supertramp), a man who hiked across North America into the Alaskan wilderness in the early 1990s. The film stars Emile Hirsch as McCandless and Marcia Gay Harden and William Hurt as his parents; it also features Jena Malone, Catherine Keener, Brian Dierker, Vince Vaughn, Kristen Stewart, and Hal Holbrook. The film premiered during the 2007 Rome Film Fest and later opened outside Fairbanks, Alaska, on September 21, 2007. The film received critical acclaim and grossed $56 million worldwide. It was nominated for two Golden Globes and won the award for Best Original Song: Guaranteed by Eddie Vedder. It was also nominated for two Academy Awards: Best Editing and Best Supporting Actor for Holbrook.",
                                Categories=new List<Category>(){categories[4],categories[1],new Category() {Name="Biography" } },
                                Votes=new List<Vote>(){votes[3],votes[2]},
                            },
                            new Movie
                            { //Advanture/Drama/Fantasy
                                MovieTitle = "Harry Potter and the Deathly Hallows: Part 2",
                                MovieDescription = "Harry, Ron, and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.",
                                MovieImage = "Harry_Potter.jpg",
                                MovieAbout = "IMDB rating is 8.1. It nominated for 3 Oscars. Harry Potter and the Deathly Hallows – Part 2 is a 2011 fantasy film directed by David Yates and distributed by Warner Bros. Pictures. It is the second of two cinematic parts based on J. K. Rowling's 2007 novel of the same name and the eighth and final instalment in the Harry Potter film series. It was written by Steve Kloves and produced by David Heyman, David Barron, and Rowling. The story continues to follow Harry Potter's quest to find and destroy Lord Voldemort's Horcruxes in order to stop him once and for all. The film stars Daniel Radcliffe as Harry Potter, alongside Rupert Grint and Emma Watson as Harry's best friends, Ron Weasley and Hermione Granger. Principal photography began on 19 February 2009, and was completed on 12 June 2010, with reshoots taking place in December 2010. Part 2 was released in 2D, 3-D and IMAX cinemas worldwide from 13 to 15 July 2011, and is the only Harry Potter film to be released in 3-D. The film was a commercial success and one of the best-reviewed films of 2011, earning praise for the acting, Yates's direction, musical score, visual effects, cinematography, action sequences, and satisfying conclusion of the saga.",
                                Categories=new List<Category>(){categories[4],categories[1], new Category() { Name = "Fantasy" } },
                                Votes=new List<Vote>(){votes[4],votes[3]},
                            },
                            new Movie
                            { //Advanture/Drama/Action
                                MovieTitle = "The Lord of the Rings: The Return of the King",
                                MovieDescription = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                                MovieImage = "LordOfRings.jpg",
                                MovieAbout = "IMDB rating is 8.9. It won 11 Oscars. The Lord of the Rings: The Return of the King is a 2003 epic fantasy adventure film directed by Peter Jackson, based on the third volume of J. R. R. Tolkien's The Lord of the Rings. The film is the final instalment in the Lord of the Rings trilogy and was produced by Barrie M. Osborne, Jackson and Fran Walsh, and written by Walsh, Philippa Boyens and Jackson. Continuing the plot of The Two Towers, Frodo, Sam and Gollum are making their final way toward Mount Doom in Mordor in order to destroy the One Ring, unaware of Gollum's true intentions, while Gandalf, Aragorn, Legolas, Gimli and the rest are joining forces together against Sauron and his legions in Minas Tirith. It was preceded by The Fellowship of the Ring (2001) and The Two Towers (2002).The film features an ensemble cast including Elijah Wood, Ian McKellen, Liv Tyler, Viggo Mortensen, Sean Astin, Cate Blanchett, John Rhys-Davies, Bernard Hill, Billy Boyd, Dominic Monaghan, Orlando Bloom, Hugo Weaving, Miranda Otto, David Wenham, Karl Urban, John Noble, Andy Serkis, Ian Holm, and Sean Bean. The Return of the King was financed and distributed by American studio New Line Cinema, but filmed and edited entirely in Jackson's native New Zealand, concurrently with the other two parts of the trilogy. It premiered on 1 December 2003 at the Embassy Theatre in Wellington and was theatrically released on 17 December 2003 in the United States, and on 18 December 2003 in New Zealand. The film was highly acclaimed by both critics and audiences, who considered it to be a landmark in filmmaking and the fantasy film genre. It grossed over $1.1 billion worldwide, making it the highest-grossing film of 2003 and the second highest-grossing film of all time at the time of its release, as well as the highest-grossing film released by New Line Cinema.",
                                Categories=new List<Category>(){categories[4],categories[1], categories[0] },
                                Votes=new List<Vote>(){votes[1],votes[2],votes[3],votes[4]},
                            },
                            new Movie
                            { //Drama/Mystery/Sci-Fi
                                MovieTitle = "The Prestige",
                                MovieDescription = "After a tragic accident, two stage magicians engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.",
                                MovieImage = "ThePrestije.jpg",
                                MovieAbout = "IMDB rating is 8.5. It nominated for 2 Oscars. The Prestige is a 2006 science fiction psychological thriller film directed by Christopher Nolan, written by Nolan and his brother Jonathan, based on the 1995 novel of the same name by Christopher Priest. It follows Robert Angier and Alfred Borden, rival stage magicians in London at the end of the 19th century. Obsessed with creating the best stage illusion, they engage in competitive one-upmanship, with fatal results.</p> <p>The film stars Hugh Jackman as Robert Angier and Christian Bale as Alfred Borden. It also stars Scarlett Johansson, Michael Caine, Piper Perabo, Andy Serkis, Rebecca Hall, and David Bowie as Nikola Tesla. The film reunites Nolan with actors Bale and Caine from Batman Begins and returning cinematographer Wally Pfister, production designer Nathan Crowley, and editor Lee Smith. The Prestige was released on October 20, 2006, to positive reviews and moderate box-office returns, grossing $109 million worldwide against a production budget of $40 million. It garnered Academy Award nominations for Best Art Direction and Best Cinematography.",
                                Categories=new List<Category>(){categories[4],categories[5],categories[7] },
                                Votes=new List<Vote>(){votes[3],votes[0]}
                            }
                        };
            var users = new List<User>()
            {
                new User()
                {
                    UserName="TimRobbins",Email="tim@gmail.com",Password="1234",ImageUrl="tim.jpg"
                },
                new User()
                {
                    UserName="EmmaWatson",Email="emma@gmail.com",Password="1234",ImageUrl="emma.jpg"
                },
                new User()
                {
                    UserName="TomHanks",Email="tom@gmail.com",Password="1234",ImageUrl="tom.jpg"
                },
                new User()
                {
                    UserName="NataliaPortman",Email="portman@gmail.com",Password="1234",ImageUrl="portman.jpg"
                }
            };
            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Tom Hanks",
                    Biography = "Hanks made his breakthrough with leading roles in a series of comedy films which received positive media attention, such as Splash (1984), Bachelor Party (1984), Big (1988) and A League of Their Own (1992). He won two consecutive Academy Awards for Best Actor for starring as a gay lawyer suffering from AIDS in Philadelphia (1993) and the title character in Forrest Gump (1994). Hanks collaborated with film director Steven Spielberg on five films: Saving Private Ryan (1998), Catch Me If You Can (2002), The Terminal (2004), Bridge of Spies (2015), and The Post (2017), as well as the 2001 miniseries Band of Brothers, which launched him as a director, producer, and screenwriter. Hanks's other films include the romantic comedies Sleepless in Seattle (1993) and You've Got Mail (1998); the dramas Apollo 13 (1995), The Green Mile (1999), Cast Away (2000), Road to Perdition (2002), and Cloud Atlas (2012); and the biographical dramas Charlie Wilson's War (2007), Captain Phillips (2013), Saving Mr. Banks (2013), Sully (2016), A Beautiful Day in the Neighborhood (2019), and News of the World (2020). He has also appeared as the title character in the Robert Langdon film series, and has voiced Sheriff Woody in the Toy Story film series (1995–present).",
                    User=users[2]
                },
                 new Person()
                 {
                     Name="Natalia Portman",
                     Biography="Portman began her acting career at age 12, when she starred as the young protégée of a hitman in the action drama film Léon: The Professional (1994). While in high school, she made her Broadway theatre debut in a 1998 production of The Diary of a Young Girl and gained international recognition for starring as Padmé Amidala in Star Wars: Episode I – The Phantom Menace (1999). From 1999 to 2003, Portman attended Harvard University for a bachelor's degree in psychology, while continuing to act in the Star Wars prequel trilogy (2002, 2005) and in The Public Theater's 2001 revival of Anton Chekhov's play The Seagull. In 2004, Portman was nominated for an Academy Award for Best Supporting Actress and won a Golden Globe Award for playing a mysterious stripper in the romantic drama Closer.",
                     User=users[3]
                 }
            };
            var crews = new List<Crew>()
            {
                new Crew()
                {
                    Movie=movies[1],Person=people[0],Job="Director"
                },
                new Crew()
                {
                    Movie=movies[4],Person=people[1],Job="Assistant Director"
                }
            };
            var casts = new List<Cast>()
            {
                new Cast()
                {
                    Movie=movies[4],Person=people[1],Name="Mathilda",Chracter="A young girl"
                },
                new Cast()
                {
                    Movie=movies[1],Person=people[0],Name="Forrest",Chracter="Actor"
                }
            };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(categories);
                }
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }
                if (context.Directors.Count() == 0)
                {
                    context.Directors.AddRange(users);
                }
                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }
                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }
                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }
                if (context.Votes.Count() == 0)
                {
                    context.Votes.AddRange(votes);
                }
                context.SaveChanges();
            }
        }

    }
}
