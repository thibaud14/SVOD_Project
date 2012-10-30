class VideoLangue < ActiveRecord::Base
 # attr_accessible
  belongs_to :video
  belongs_to :ref_video_langue

end
