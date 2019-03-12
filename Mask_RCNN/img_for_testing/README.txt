Default values are set to simply the use of the parser.

For training with the vehicle dataset provided in the datasets folder use:
Example: python vehicle.py train

With other pretrained weights (Coco can also used) use:
Example: python vehicle.py train --weights /path/to/specific/weights.h5

To use the prediction on an image (with the weights from us), put the image inside of the img_for_testing folder and use the command:
Example: python vehicle.py splash

It is possible to select another folder på using:
python vehicle.py splash --imagedir /path/to/folder/

Additional other weights can be used like this (can use coco aswell, but download is required, approx 500MB):
python vehicle.py splash --weights /path/to/weights.h5

The results are placed inside of img_vid_results

To apply the prediciton a video use :
python vehicle.py splash --video /path/to/specific/video.avi

PS: python terminal and powershell works.

PS: if mrcnn implementation does not work, try to the current folder to /Final-Project/Mask_RCNN/Code/





