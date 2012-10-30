class VideoPeople < ActiveRecord::Base
  # attr_accessible :title, :body

  belongs_to :ref_professions
  belongs_to :video
  belongs_to :people
end
