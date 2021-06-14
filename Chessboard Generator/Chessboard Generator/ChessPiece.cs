using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chessboard_Generator
{
    class ChessPiece : Sprite
    { 
        public ChessPiece(): base() 
        {

        }

        public ChessPiece(Texture2D inSpriteTexture, Vector2 inSpritePosition, Color inSpriteColor, Rectangle inSpriteBox, float inScaleFactor) :
            base(inSpriteTexture, inSpritePosition, inSpriteColor, inSpriteBox, inScaleFactor)

        {


        }
        public Rectangle ChessPieceTexture
        {
            get { return spriteBox; }
            set { spriteBox = value; }

        }
    }
}
