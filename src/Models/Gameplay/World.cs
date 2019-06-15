using System;
using System.Security.Cryptography;
using Tetris.Models.Gameplay.Terminos;
using Tetris.Models.Utilities;
using Sfs = SFML.System;

namespace Tetris.Models.Gameplay
{
    public class World : IWorld
    {
        public static Sfs.Vector2i WorldBounds;
        public ITermino CurrentPiece { get; set; }
        public bool[,] Matrix { get; set; }
        private ITermino[] TerminoPrototypes { get; }
        public bool WorldEnded { get; private set; }

        public World(int width, int height)
        {
            WorldBounds = new Sfs.Vector2i(width, height);
            Matrix = new bool[height, width];
            Matrix.FillArray(false);
            
            var terminoFactory = new TerminoFactory();
            TerminoPrototypes = new[]
            {
                terminoFactory.Create(ETerminoName.I),
                terminoFactory.Create(ETerminoName.J),
                terminoFactory.Create(ETerminoName.L),
                terminoFactory.Create(ETerminoName.O),
                terminoFactory.Create(ETerminoName.S),
                terminoFactory.Create(ETerminoName.T),
                terminoFactory.Create(ETerminoName.Z)
            };
            CurrentPiece = NextTermino();
            WorldEnded = false;
        }

        public void UpdateCurrent(Sfs.Time dt)
        {
            if (!CurrentPiece.Grounded)
            {
                return;
            }
            
            CurrentPiece = NextTermino();
            if (CurrentPiece.IsOccupied(CurrentPiece.Position, Matrix))
            {
                WorldEnded = true;
            }
        }
        private ITermino NextTermino()
        {
            var rnd = new Random();
            return TerminoPrototypes[rnd.Next(0, TerminoPrototypes.Length)].Clone() as Termino;
        }
    }
}