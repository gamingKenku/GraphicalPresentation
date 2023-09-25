namespace GraphicalPresentationLab4
{
    public class ItemForDrawing
    {
        public enum TypeOfObject : int
        {
            Point = 0,
            Line = 1,
            Rectangle = 2,
            Ellipse = 3,
            String = 4,
        }
        public Point start_coordinate {  get; set; }
        public Point end_coordinate { get; set; }
        public Size size { get; set; }
        public String? text { get; set; }
        public int type_of_object { get; set; }

        public ItemForDrawing(Point coordinate)
        {
            start_coordinate = coordinate;
            this.type_of_object = (int)TypeOfObject.Point;
        }
        public ItemForDrawing(int type_of_object, Point coordinate, Size size)
        {
            this.start_coordinate = coordinate;
            this.size = size;
            this.type_of_object = type_of_object;
        }
        public ItemForDrawing(Point start_coordinate, Point end_coordinate)
        {
            this.start_coordinate= start_coordinate;
            this.end_coordinate= end_coordinate;
            this.type_of_object= (int)TypeOfObject.Line;
        }
        public ItemForDrawing(Point start_coordinate, String text)
        {
            this.text = text;
            this.start_coordinate = start_coordinate;
            this.type_of_object =(int)TypeOfObject.String;
        }
    }
}