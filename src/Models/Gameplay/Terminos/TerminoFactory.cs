using System;
using Sfg = SFML.Graphics;

namespace Tetris.Models.Gameplay.Terminos
{
    public class TerminoFactory
    {
        public ITermino Create(ETerminoName terminoName)
        {
            switch (terminoName)
            {
                case ETerminoName.I:
                    return CreateI();
                case ETerminoName.J:
                    return CreateJ();
                case ETerminoName.L:
                    return CreateL();
                case ETerminoName.O:
                    return CreateO();
                case ETerminoName.S:
                    return CreateS();
                case ETerminoName.T:
                    return CreateT();
                case ETerminoName.Z:
                    return CreateZ();
                default:
                    throw new ArgumentOutOfRangeException(nameof(terminoName), terminoName, null);
            }
        }
        
        //==============================\\
        // X0Y3 || X1Y3 || X2Y3 || X3Y3 \\
        //==============================\\
        // X0Y2 || X1Y2 || X2Y2 || X3Y2 \\
        //==============================\\
        // X0Y1 || X1Y1 || X2Y1 || X3Y1 \\
        //==============================\\
        // X0Y0 || X1Y0 || X2Y0 || X3Y0 \\
        //==============================\\

        private static ITermino CreateI()
        {
            return new Termino(
                new ushort[]{
                    (int) (ETerminoShape.X1Y0 | ETerminoShape.X1Y1 | ETerminoShape.X1Y2 | ETerminoShape.X1Y3),
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2 | ETerminoShape.X3Y2),
                    (int) (ETerminoShape.X2Y0 | ETerminoShape.X2Y1 | ETerminoShape.X2Y2 | ETerminoShape.X2Y3),
                    (int) (ETerminoShape.X0Y1 | ETerminoShape.X1Y1 | ETerminoShape.X2Y1 | ETerminoShape.X3Y1)
                }, 
                Sfg.Color.Red
            );
        }
        
        private static ITermino CreateJ()
        {
            return new Termino(
                new ushort[]{
                    (int) (ETerminoShape.X0Y1 | ETerminoShape.X1Y1 | ETerminoShape.X1Y2 | ETerminoShape.X1Y3),
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2 | ETerminoShape.X0Y3),
                    (int) (ETerminoShape.X1Y3 | ETerminoShape.X0Y3 | ETerminoShape.X0Y2 | ETerminoShape.X0Y1),
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2 | ETerminoShape.X2Y1)
                }, 
                Sfg.Color.Green
            );
        }
        
        private static ITermino CreateL()
        {
            return new Termino(
                new ushort[]{
                    (int) (ETerminoShape.X1Y1 | ETerminoShape.X1Y2 | ETerminoShape.X2Y1 | ETerminoShape.X1Y3),
                    (int) (ETerminoShape.X0Y1 | ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2),
                    (int) (ETerminoShape.X0Y3 | ETerminoShape.X1Y3 | ETerminoShape.X1Y2 | ETerminoShape.X1Y1),
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2 | ETerminoShape.X2Y3)
                }, 
                Sfg.Color.Blue
            );
        }
        
        private static ITermino CreateO()
        {
            return new Termino(
                new ushort[]{
                    (int) (ETerminoShape.X0Y3 | ETerminoShape.X1Y3 | ETerminoShape.X0Y2 | ETerminoShape.X1Y2),
                    (int) (ETerminoShape.X0Y3 | ETerminoShape.X1Y3 | ETerminoShape.X0Y2 | ETerminoShape.X1Y2),
                    (int) (ETerminoShape.X0Y3 | ETerminoShape.X1Y3 | ETerminoShape.X0Y2 | ETerminoShape.X1Y2),
                    (int) (ETerminoShape.X0Y3 | ETerminoShape.X1Y3 | ETerminoShape.X0Y2 | ETerminoShape.X1Y2)
                }, 
                Sfg.Color.Yellow
            );
        }
        
        private static ITermino CreateS()
        {
            return new Termino(
                new ushort[]{
                    (int) (ETerminoShape.X0Y1 | ETerminoShape.X1Y1 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2),
                    (int) (ETerminoShape.X0Y3 | ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X1Y1),
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X1Y3 | ETerminoShape.X2Y3),
                    (int) (ETerminoShape.X1Y2 | ETerminoShape.X1Y3 | ETerminoShape.X2Y2 | ETerminoShape.X2Y1)
                }, 
                Sfg.Color.Cyan
            );
        }
        
        private static ITermino CreateT()
        {
            return new Termino(
                new ushort[]{
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2 | ETerminoShape.X1Y1),
                    (int) (ETerminoShape.X1Y3 | ETerminoShape.X1Y2 | ETerminoShape.X1Y1 | ETerminoShape.X0Y2),
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2 | ETerminoShape.X1Y3),
                    (int) (ETerminoShape.X2Y2 | ETerminoShape.X1Y2 | ETerminoShape.X1Y3 | ETerminoShape.X1Y1)
                }, 
                Sfg.Color.Magenta
            );
        }
        
        private static ITermino CreateZ()
        {
            return new Termino(
                new ushort[]{
                    (int) (ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X1Y1 | ETerminoShape.X2Y1),
                    (int) (ETerminoShape.X0Y1 | ETerminoShape.X0Y2 | ETerminoShape.X1Y2 | ETerminoShape.X1Y3),
                    (int) (ETerminoShape.X0Y3 | ETerminoShape.X1Y3 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2),
                    (int) (ETerminoShape.X1Y1 | ETerminoShape.X1Y2 | ETerminoShape.X2Y2 | ETerminoShape.X2Y3)
                }, 
                new Sfg.Color(128,0,128)
            );
        }
        
        
    }
}