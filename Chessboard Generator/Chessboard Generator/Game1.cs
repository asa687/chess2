using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*Chess piece =initialisec and chessboard generatior need to be merged*/
namespace Chessboard_Generator
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D square, BlackBishop, BlackKing, BlackKnight, BlackPawn, BlackQueen, BlackRook, WhiteBishop, WhiteKing, WhiteKnight, WhitePawn, WhiteQueen, WhiteRook;
        Square[,] squareArray;
        ChessPiece[,] pieceArray;

        public void InitialiseSquares(int inColumns, int inRows)
        {
            squareArray = new Square[inRows, inColumns];
            Vector2 squarePosition;
            Rectangle squareBounds;
            Color[] colorArray = new Color[2] { Color.Black, Color.White };
            float scale = 1;
            int iteration = 0;
            for (int row = 0; row <= squareArray.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= squareArray.GetUpperBound(1); column++)
                {           
                    Color squareColor = colorArray[iteration];/*colour array needs to alternate between 1 and 0 */
                    squarePosition = new Vector2(column * (float)square.Width, row * (float)square.Height);
                    squareBounds = new Rectangle((int)squarePosition.X, (int)squarePosition.Y, square.Width, square.Height);
                    squareArray[row, column] = new Square(square, squarePosition, squareColor, squareBounds, scale);
                    iteration = Switch(iteration);

                }
                iteration = Switch(iteration);
            }
        }

        public int Switch(int colour)
        {
            switch (colour)
            {
                case 0:
                    return 1;
                case 1:
                    return 0;
                default:
                    return 0;
            }
        }

        public void InitialisePieces(int x, int y, Texture2D pieceTexture, Color pieceColor)
        {
            Vector2 piecePosition;
            Rectangle pieceBounds;
            pieceArray = new ChessPiece[x,y];
            float scale = 1;
            piecePosition = new Vector2(x * (float)pieceTexture.Width, y * (float)pieceTexture.Height);
            pieceBounds = new Rectangle((int)piecePosition.X, (int)piecePosition.Y, pieceTexture.Width, pieceTexture.Height);
            pieceArray[x, y] = new ChessPiece(pieceTexture, piecePosition, pieceColor, pieceBounds, scale);


        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice); 


            // TODO: use this.Content to load your game content here
            square = Content.Load<Texture2D>("square");

            BlackBishop = Content.Load<Texture2D>("BlackBishopPlaceholder");
            BlackKing = Content.Load<Texture2D>("BlackKingPlaceholder");
            BlackKnight = Content.Load<Texture2D>("BlackKnightPlaceholder");
            BlackPawn = Content.Load<Texture2D>("BlackPawnPlaceholder");
            BlackQueen = Content.Load<Texture2D>("BlackQueenPlaceholder");
            BlackRook = Content.Load<Texture2D>("BlackRookPlaceholder");

            WhiteBishop = Content.Load<Texture2D>("WhiteBishopPlaceholder");
            WhiteKing = Content.Load<Texture2D>("WhiteKingPlaceholder");
            WhiteKnight = Content.Load<Texture2D>("WhiteKnightPlaceholder");
            WhitePawn = Content.Load<Texture2D>("WhitePawnPlaceholder");
            WhiteQueen = Content.Load<Texture2D>("WhiteQueenPlaceholder");
            WhiteRook = Content.Load<Texture2D>("WhiteRookPlaceholder");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            InitialiseSquares(8, 8);
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (y == 1)
                    {
                        InitialisePieces(x, y, BlackPawn, Color.Black); 
                    }
                    if (x == 0 && y == 0 || x == 7 && y == 0)
                    {
                        InitialisePieces(x, y, BlackRook, Color.Black);
                    }
                    if (x == 1 && y == 0 || x == 6 && y == 0)
                    {
                        InitialisePieces(x, y, BlackKnight, Color.Black);
                    }
                    if (x == 2 && y == 0 || x == 5 && y == 0)
                    {
                        InitialisePieces(x, y, BlackBishop, Color.Black);
                    }
                    if (x == 3 && y == 0)
                    {
                        InitialisePieces(x, y, BlackQueen, Color.Black);
                    }
                    if (x == 4 && y == 0)
                    {
                        InitialisePieces(x, y, BlackKing, Color.Black);
                    }

                    // replace y coordinastes and black with white
                    if (y == 7)
                    {
                        InitialisePieces(x, y, WhitePawn, Color.White);
                    }
                    if (x == 0 && y == 0 || x == 7 && y == 0)
                    {
                        InitialisePieces(x, y, WhiteRook, Color.Black);
                    }
                    if (x == 1 && y == 0 || x == 6 && y == 0)
                    {
                        InitialisePieces(x, y, WhiteKnight, Color.Black);
                    }
                    if (x == 2 && y == 0 || x == 5 && y == 0)
                    {
                        InitialisePieces(x, y, WhiteBishop, Color.Black);
                    }
                    if (x == 3 && y == 0)
                    {
                        InitialisePieces(x, y, WhiteQueen, Color.Black);
                    }
                    if (x == 4 && y == 0)
                    {
                        InitialisePieces(x, y, WhiteKing, Color.Black);
                    }


                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);
            spriteBatch.Begin();
            foreach (Square squares in squareArray)
            {
                squares.Draw(spriteBatch);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
