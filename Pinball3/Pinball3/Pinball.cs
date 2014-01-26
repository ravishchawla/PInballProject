1using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Pinball3
{

    /*
     *Ravish Chawla
     *130214.23
     * 
     **/

	/*
	This class contains the code for checking interserction and reflection
	and number of bounces for a specific angle. It implements the methods
	outlined in the project discription. 	
	*/

    public class Pinball
    {
        public static double t;

        static Vector2D center1, center2, center3;
        Vector2D position, vel;
        static int rad;
        int count = 0;
        
         List<String> centers;

	/*
		This method checks for intersection between the current center, 
		the position, velocity, and radius. It returns the time at which
		the particle will hit the circle. It returns int.MaxValue (~infinity)
		if there is no intersection.
	*/


        public static double intersection(Vector2D center, int rad, Vector2D currPos, Vector2D currVel)
        {
            
            Vector2D c_x = center.subtract(currPos);
            double v_c_x = currVel.dotProduct(c_x);
            
            if (v_c_x <= 0)
            {

                return int.MaxValue;
            }

            double d = (v_c_x * v_c_x) - c_x.dotProduct(c_x) + (rad * rad);

            if (d <= 0)
                return int.MaxValue;

            return(v_c_x - (double)Math.Sqrt((double)d));

        }

	/*
		This method checks for reflection when a particle hits a circle. It takes in a 
		center, a position and velocity, and returns the new reflected velocity after hitting. 

	*/

        public static Vector2D reflect(Vector2D center, Vector2D currPos, Vector2D currVel)
        {
            Vector2D c_x = center.subtract(currPos);

            double tvt = (currVel.scalar(2).dotProduct(c_x)) / c_x.dotProduct(c_x);

            Vector2D newVel = currVel.subtract(c_x.scalar(tvt));

            return newVel;

        }


	/*
		This method checks for the next intersection point, depending on where the particle
		is right now. It checks for intersection between the three circles, and returns 
		the one with the lowest time till intersection. 
	
	
	*/
        public static Vector2D nextIntersection(Vector2D displacement, Vector2D velocity)
        {
            double d1 = intersection(center1, rad, displacement, velocity);
            double d2 = intersection(center2, rad, displacement, velocity);
            double d3 = intersection(center3, rad, displacement, velocity);

            if (d1 < d2 && d1 < d3)
                return center1;

            else if (d2 < d1 && d2 < d3)
                return center2;

            else if (d3 < d1 && d3 < d2)
                return center3;

            else
            return null;

        }


	/*
	
		This method initiailizes the static variables
		of the class, which are the sides, radii, and the center
		positions. They will not need to be changed and modified ever
		again the program, so they were made static. 
	
	*/


        public Pinball()
        {
            int s = 6;

            center1 = new Vector2D(0, s * Math.Sqrt(3) / 3);
            center2 = new Vector2D(-s / 2, -s * Math.Sqrt(3) / 6);
            center3 = new Vector2D(s / 2, -s * Math.Sqrt(3) / 6);

            rad = 1;



        }
		
		
		/*
			this method returns the list of the centers
			which had been intersected. 
		
		
		*/

        public List<String> getList()
        {

            return centers;
        }


		/*
		
			this is the driver method of this class. 
			It takes in an angle in degrees, and initliazes
			the variables in terms of that. 
			
			Then, it gets the next intersection pont, and runs
			in a while loop till the intersection point is null (meaning
			there is no intersection point). In the loop, 
			the next intersection circle is added to the list, 
			the position is updated along with the velocity, and the total count 
			is incremented. 
			
			It returns the total count at the end. 
			
			
		
		
		*/

        public int run(double degrees){

            degrees = degrees * (Math.PI / 180);
            position = new Vector2D(0, 0);
            vel = new Vector2D(Math.Cos(degrees), Math.Sin(degrees));
           centers = new List<String>();
        
        Vector2D next = Pinball.nextIntersection(position, vel);
        
        count = 0;
            while (next != null)
            {
                if (next.x == 0)
                    centers.Add("circle1");
                else if (next.x == -3)
                    centers.Add("circle2");
                else if (next.x == 3)
                    centers.Add("circle3");

                t = Pinball.intersection(next, rad, position, vel);

                position = position.add(vel.scalar(t));
                
                vel = reflect(next, position, vel);
                
                next = Pinball.nextIntersection(position, vel);
                count++;
             
            }

            return count;

    }

    }
}
