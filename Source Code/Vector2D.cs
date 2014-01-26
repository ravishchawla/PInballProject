using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *Ravish Chawla
 *130214.23
 * 
 **/


namespace Pinball3
{

	/*
	
	This a vector class, which contains two values, an x and a y. 
	it also has relavent methods to vectors. 
	
	*/
	
	public class Vector2D
    {
        public double x;
        public double y;


	/*
		this method is a constructor, and initliazes
		the value of the vectors. 
	*/
        public Vector2D(double x, double y)
        {

            this.x = x;
            this.y = y;
        }


	/*
		this method returns the dot product of 
		this vector and its parameter. 
	*/
        public double dotProduct(Vector2D d2)
        {

            return (x * d2.x + y * d2.y);

        }


	/*
		this method returns the difference
		of this vector and its parameter. 
	
	*/
        public Vector2D subtract(Vector2D d2)
        {

            double a = x - d2.x;
            double b = y - d2.y;

            return (new Vector2D(a, b));

        }


	/*
		this method returns the sum of this
		vector and its parameter. 
	
	*/
        public Vector2D add(Vector2D d2)
        {

            double a = x + d2.x;
            double b = y + d2.y;

            return (new Vector2D(a, b));

        }


	/*
		this method returns the sclar product
		of this vector and its parameter. 
	
	*/
        public Vector2D scalar(double d4)
        {

            double a = d4 * x;
            double b = d4 * y;

            return (new Vector2D(a, b));

        }
	/*
		this method returns a string representation
		of this vector. 
	
	*/
        public String toString()
        {
            double a = Math.Round(x, 3);
            double b = Math.Round(y, 3);
            return "(" + a + ", " + b + ")";


        }
    }

}
1

/*
  public class Vector2D{
        
        public double x;
        public double y;
        
        public Vector2D(double x1, double y1){
            
               x = x1;
               y = y1;
            
            
        }
        
        public double dotProduct(Vector2D d2){
            
            return (x*d2.x + y*d2.y);
            
            
        }
        
        
        public Vector2D subtract(Vector2D d2)
        {
            double a = x - d2.x;
            double b = y - d2.y;
            
            return (new Vector2D(a,b));
            
            
            
        }
        
        public Vector2D add(Vector2D d3){
            
            double a = x + d3.x;
            double b = y + d3.y;
            
            return (new Vector2D(a,b));
            
        }
        
        public Vector2D scalar(double d4){
            
            double a = d4*x;
            double b = d4*y;
            
            return (new Vector2D(a,b));
            
            
            
        }
        
        
    }
  
*/